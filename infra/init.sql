use `aws-projeto-final`;
CREATE TABLE time (
    id char(38),
    nome varchar(100),
    localidade varchar(30),
    PRIMARY KEY (id)
);

INSERT INTO `aws-projeto-final`.`time` (`id`,`nome`, `localidade`) VALUES ('f20156bd-10fc-418a-9e42-2cc2b69f3519','PUC-MINAS', 'BRASIL');
INSERT INTO `aws-projeto-final`.`time` (`id`,`nome`, `localidade`) VALUES ('37e66c17-fe3c-49c0-a988-ae09f41143b6','PUC-RIO', 'BRASIL');

CREATE TABLE jogador (
    id char(38),
    nome varchar(100),
    dataNascimento datetime,
    pais varchar(30),
    timeId char(38),
    PRIMARY KEY (id),
    FOREIGN KEY (timeId) REFERENCES time(id)
);

INSERT INTO `aws-projeto-final`.`jogador` (`id`,`nome`, `dataNascimento`, `pais`, `timeId`) VALUES ('480c0a9d-f129-4f85-844d-00e039ea3e90','jose', '1989-12-12', 'BR', 'f20156bd-10fc-418a-9e42-2cc2b69f3519');
INSERT INTO `aws-projeto-final`.`jogador` (`id`,`nome`, `dataNascimento`, `pais`, `timeId`) VALUES ('b93c0dfa-2d47-43c9-8004-85fa8307b1cf','tamara', '1991-01-04', 'BR', '37e66c17-fe3c-49c0-a988-ae09f41143b6');
INSERT INTO `aws-projeto-final`.`jogador` (`id`,`nome`, `dataNascimento`, `pais`, `timeId`) VALUES ('2702558c-c023-487d-9516-af7ba6ccb09a','david', '1975-05-02', 'EN', 'f20156bd-10fc-418a-9e42-2cc2b69f3519');
INSERT INTO `aws-projeto-final`.`jogador` (`id`,`nome`, `dataNascimento`, `pais`, `timeId`) VALUES ('5fc1ddad-7e0c-49e9-93dd-f052b8977fee','leonel', '1987-06-24', 'AR', '37e66c17-fe3c-49c0-a988-ae09f41143b6');

CREATE TABLE transferencia (
    id char(38),
    jogador char(38),
    timeOrigem char(38),
    timeDestino char(38),
    data datetime,
    valor decimal(10,2),
    PRIMARY KEY (id),
    FOREIGN KEY (jogador) REFERENCES jogador(id),
    FOREIGN KEY (timeOrigem) REFERENCES time(id),
    FOREIGN KEY (timeDestino) REFERENCES time(id)
);

INSERT INTO `aws-projeto-final`.`transferencia` (`id`,`jogador`, `timeOrigem`, `timeDestino`, `data`, `valor`) 
VALUES ('97162ec0-5954-4dbb-90ff-860fb773fd1c','2702558c-c023-487d-9516-af7ba6ccb09a', 'f20156bd-10fc-418a-9e42-2cc2b69f3519', '37e66c17-fe3c-49c0-a988-ae09f41143b6', '2003-07-01', 37.5);
INSERT INTO `aws-projeto-final`.`transferencia` (`id`,`jogador`, `timeOrigem`, `timeDestino`, `data`, `valor`) 
VALUES ('0cf55e7f-4293-4f1f-92b8-1543c6d29b8a','5fc1ddad-7e0c-49e9-93dd-f052b8977fee', '37e66c17-fe3c-49c0-a988-ae09f41143b6', 'f20156bd-10fc-418a-9e42-2cc2b69f3519', '2021-08-10', 80);

CREATE TABLE competicao (
    id char(38),
    nome char(50),
    PRIMARY KEY (id)
);

INSERT INTO `aws-projeto-final`.`competicao` (`id`,`nome`) 
VALUES ('035ef8c6-6990-4921-88fe-d0d048752e5e','brasileirão');

CREATE TABLE partida (
    id char(38),
    time_casa char(38),
    time_visitante char(38),
    competicao char(38),
    PRIMARY KEY (id),
    FOREIGN KEY (competicao) REFERENCES competicao(id),
    FOREIGN KEY (time_casa) REFERENCES time(id),
    FOREIGN KEY (time_visitante) REFERENCES time(id)
    
);

INSERT INTO `aws-projeto-final`.`partida` (`id`,`time_casa`,`time_visitante`,`competicao`) 
VALUES ('e55f0a59-a31a-4eb8-a75a-3cc8b3fd580d','f20156bd-10fc-418a-9e42-2cc2b69f3519','37e66c17-fe3c-49c0-a988-ae09f41143b6','035ef8c6-6990-4921-88fe-d0d048752e5e');
INSERT INTO `aws-projeto-final`.`partida` (`id`,`time_casa`,`time_visitante`,`competicao`)  
VALUES ('17aa1d60-7fda-4332-9b72-5fcd472050c3','37e66c17-fe3c-49c0-a988-ae09f41143b6','f20156bd-10fc-418a-9e42-2cc2b69f3519','035ef8c6-6990-4921-88fe-d0d048752e5e');

CREATE TABLE evento (
    id char(38),
    competicao char(38),
    partida char(38),
    time char(38),
    tipo_evento INT,
    jogador_principal char(38),
    jogador_secundario char(38),
    PRIMARY KEY (id),
    FOREIGN KEY (competicao) REFERENCES competicao(id),
    FOREIGN KEY (partida) REFERENCES partida(id),
    FOREIGN KEY (time) REFERENCES time(id),
    FOREIGN KEY (jogador_principal) REFERENCES jogador(id),
    FOREIGN KEY (jogador_secundario) REFERENCES jogador(id)
    
);