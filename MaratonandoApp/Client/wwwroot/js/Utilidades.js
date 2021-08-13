var db = new Dexie('WacthedOffline');
var dbVersion = 1;

db.version(dbVersion).stores({
    watched: 'id++'
});

async function ObterEpisodiosPraSincronizar() {
    return await {
        EpisodiosParaMarcar: await db.watched.toArray()
    };
}

async function apagarDado(tabela, id) {
    await db[tabela].where({ "id": id }).delete();
}

async function AtualizarSincronacoesEmEspera() {
    const emEspera = await db.watched.count();

    return emEspera;
}

async function GuardarEpisodioParaMarcar(idep) {
    await db.watched.put({idep})
}