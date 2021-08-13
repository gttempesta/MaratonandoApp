self.importScripts('./service-worker-assets.js');

const cacheNamePrefix = 'offline-cache-';
const cacheName = `${cacheNamePrefix}${self.assetsManifest.version}`;
const cacheNameDynamic = 'dynamic-cache';
const offlineAssetsInclude = [/\.dll$/, /\.pdb$/, /\.wasm/, /\.html/, /\.js$/, /\.json$/, /\.css$/, /\.woff$/, /\.png$/, /\.jpe?g$/, /\.gif$/, /\.ico$/, /\.blat$/, /\.dat$/];
const offlineAssetsExclude = [/^service-worker\.js$/];

self.addEventListener('install', evt => {
    evt.waitUntil(
        caches.open(cacheName).then(cache => {
            const assetsRequests = self.assetsManifest.assets
                .filter(asset => offlineAssetsInclude.some(pattern => pattern.test(asset.url)))
                .filter(asset => !offlineAssetsExclude.some(pattern => pattern.test(asset.url)))
                .map(asset => new Request(asset.url, { integrity: asset.hash }));
            assetsRequests.push(new Request('_configuration/MaratonandoApp.Client'));

            cache.addAll(assetsRequests);
        })
    );
});

self.addEventListener('activate', evt => {
    evt.waitUntil(
        caches.keys().then(keys => {
            return Promise.all(keys
                .filter(key => key !== cacheName && key !== cacheNameDynamic)
                .map(key => caches.delete(key))
            )
        })
    );
});

//self.addEventListener('fetch', evt => {
//    evt.respondWith(
//        caches.match(evt.request).then(cacheRes => {
//            return cacheRes || fetch(evt.request).then(fetchRes => {
//                return caches.open(cacheNameDynamic).then(cache => {
//                    cache.put(evt.request.url, fetchRes.clone());
//                    return fetchRes;
//                })
//            });
//        })
//    );
//});

self.addEventListener('fetch', function (event) {
    event.respondWith(
        // Try the network
        fetch(event.request)
            .then(function (res) {
                return caches.open(cacheNameDynamic)
                    .then(function (cache) {
                        // Put in cache if succeeds
                        cache.put(event.request.url, res.clone());
                        return res;
                    })
            })
            .catch(function (err) {
                // Fallback to cache
                return caches.match(event.request).then(res => {
                    if (res === undefined) {
                        return err;
                    }
                    return res

                });
            })
    );
});