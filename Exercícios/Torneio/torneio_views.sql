# PARTIDA VIEW
CREATE VIEW PartidaView AS
SELECT 
	p.id
	, t.nome as nome_torneio
	, e.etapa AS nome_etapa
	, p.numRodada as num_rodada
	, eq1.nome as equipe1
	, eq2.nome as equipe2
	, m.modalidade
	, eq3.nome as vencedor
	, p.empate
	, p.dataPartida as data_partida
FROM Partida p
JOIN Etapa e ON p.etapaId = e.id
JOIN Torneio t ON t.id = p.torneioId
JOIN Equipe eq1 ON p.equipe1 = eq1.id
LEFT JOIN Equipe eq2 ON p.equipe2 = eq2.id
LEFT JOIN Equipe eq3 ON p.vencedorId = eq3.id
JOIN Modalidade m ON p.modalidadeId = m.id;

# CLASSIFICATORIA VIEW
CREATE VIEW ClassificatoriaView AS
SELECT 
	t.nome as nome_torneio
    , e.nome as equipe
    , pontos
FROM Classificatoria as c
JOIN Torneio t ON c.torneioId = t.id
JOIN Equipe e ON c.equipeId = e.id
ORDER BY pontos DESC;

SELECT * FROM PartidaView;
SELECT * FROM ClassificatoriaView;