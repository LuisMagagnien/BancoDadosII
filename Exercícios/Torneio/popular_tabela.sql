-- Inserindo atletas
INSERT INTO Atleta (nome) VALUES ('João Silva');
INSERT INTO Atleta (nome) VALUES ('Maria Souza');
INSERT INTO Atleta (nome) VALUES ('Carlos Andrade');

-- Inserindo equipes
INSERT INTO Equipe (nome) VALUES ('Equipe A');
INSERT INTO Equipe (nome) VALUES ('Equipe B');
INSERT INTO Equipe (nome) VALUES ('Equipe C');

-- Inserindo etapas
INSERT INTO Etapa (etapa) VALUES ('Classificatória');
INSERT INTO Etapa (etapa) VALUES ('Quartas de Final');
INSERT INTO Etapa (etapa) VALUES ('Semifinal');
INSERT INTO Etapa (etapa) VALUES ('Final');

-- Inserindo modalidades
INSERT INTO Modalidade (modalidade) VALUES ('Futebol');
INSERT INTO Modalidade (modalidade) VALUES ('Basquete');

-- Criando um torneio
INSERT INTO Torneio (nome, equipeVencedoraId, dataInicio, dataFim) 
VALUES ('Torneio 2024', 1, '2024-09-01 10:00:00', '2024-09-30 18:00:00');

-- Associando equipes com o torneio na fase classificatória
INSERT INTO Classificatoria (torneioId, equipeId, pontos) VALUES (1, 1, 10);
INSERT INTO Classificatoria (torneioId, equipeId, pontos) VALUES (1, 2, 8);
INSERT INTO Classificatoria (torneioId, equipeId, pontos) VALUES (1, 3, 6);

-- Associando atletas às equipes
INSERT INTO EquipeAtleta (atletaId, equipeId) VALUES (1, 1);
INSERT INTO EquipeAtleta (atletaId, equipeId) VALUES (2, 1);
INSERT INTO EquipeAtleta (atletaId, equipeId) VALUES (3, 2);

-- Criando partidas
INSERT INTO Partida (torneioId, etapaId, numRodada, equipe1, equipe2, modalidadeId, vencedorId, empate, dataPartida) 
VALUES (1, 1, 1, 1, 2, 1, 1, FALSE, '2024-09-05 09:00:00');

INSERT INTO Partida (torneioId, etapaId, numRodada, equipe1, equipe2, modalidadeId, vencedorId, empate, dataPartida) 
VALUES (1, 1, 1, 2, 3, 1, 2, FALSE, '2024-09-05 13:00:00');

INSERT INTO Partida (torneioId, etapaId, numRodada, equipe1, equipe2, modalidadeId, vencedorId, empate, dataPartida) 
VALUES (1, 1, 1, 1, 3, 1, NULL, TRUE, '2024-09-05 18:00:00');
