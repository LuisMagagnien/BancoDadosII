DROP SCHEMA IF EXISTS torneio;
CREATE SCHEMA torneio;
USE torneio;

CREATE TABLE Atleta(
	id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(255)
);

CREATE TABLE Equipe(
	id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(255)
);

CREATE TABLE Etapa(
	id INT AUTO_INCREMENT PRIMARY KEY,
    etapa VARCHAR(255)
);

CREATE TABLE Modalidade(
	id INT AUTO_INCREMENT PRIMARY KEY,
    modalidade varchar(255) 
);

CREATE TABLE Torneio(
	id INT AUTO_INCREMENT PRIMARY KEY,
    nome varchar(255),
    equipeVencedoraId INT NOT NULL,
    dataInicio Datetime,
    dataFim Datetime,
    FOREIGN KEY (equipeVencedoraId) REFERENCES Equipe(id)
);

CREATE TABLE Classificatoria(
	torneioId INT NOT NULL,
    equipeId INT NOT NULL,
    pontos INT DEFAULT(0),
    FOREIGN KEY (torneioId) REFERENCES Torneio(id),
    FOREIGN KEY (equipeId) REFERENCES Equipe(id)
);

CREATE TABLE EquipeAtleta(
	atletaId INT NOT NULL,
    equipeId INT NOT NULL,
    FOREIGN KEY (atletaId) REFERENCES Atleta(id),
    FOREIGN KEY (equipeId) REFERENCES Equipe(id)
);

CREATE TABLE Partida(
	id INT AUTO_INCREMENT PRIMARY KEY,
    torneioId INT NOT NULL,
    etapaId INT NOT NULL,
    numRodada INT,
    equipe1 INT NOT NULL,
    equipe2 INT,
    modalidadeId INT NOT NULL,
    vencedorId INT DEFAULT NULL,
    empate BOOL DEFAULT(FALSE),
    dataPartida DATETIME NOT NULL,
    FOREIGN KEY (torneioId) REFERENCES Torneio(id),
    FOREIGN KEY (etapaId) REFERENCES Etapa(id),
    FOREIGN KEY (equipe1) REFERENCES Equipe(id),
    FOREIGN KEY (equipe2) REFERENCES Equipe(id),
    FOREIGN KEY (modalidadeId) REFERENCES Modalidade(id),
    FOREIGN KEY (vencedorId) REFERENCES Equipe(id)
);