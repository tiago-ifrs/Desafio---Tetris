CREATE TABLE "pontuacao" (
	"id"	INTEGER NOT NULL,
	"nome"	TEXT NOT NULL,
	"score"	INTEGER NOT NULL,
	"nivel"	INTEGER NOT NULL,
	"tempo_jogo"	TEXT NOT NULL,
	"qtd_pecas"	INTEGER NOT NULL,
	"data_score"	TEXT NOT NULL,
	"tabuleiro"	BLOB NOT NULL,
	PRIMARY KEY("id" AUTOINCREMENT)
);