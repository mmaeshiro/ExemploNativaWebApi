CREATE TABLE marca(
	marcaId int primary key identity(1,1),
	nome VARCHAR(300)
)

CREATE TABLE patrimonio(
	numeroTombo int primary key identity(1,1),
	marcaId int,
	nome VARCHAR(300),
	descricao VARCHAR(300)
)

CREATE TABLE usuario(
	usuarioId int primary key identity(1,1),
	nome VARCHAR(300),
	email VARCHAR(300),
	senha VARCHAR(300),
	role VARCHAR(300)
)

INSERT INTO marca (nome) VALUES ('nike')
INSERT INTO marca (nome) VALUES ('adidas')
INSERT INTO marca (nome) VALUES ('microsoft')

INSERT INTO patrimonio (marcaId ,nome, descricao) VALUES (1,'patrimonio nike' ,'descrição nike')
INSERT INTO patrimonio (marcaId ,nome, descricao) VALUES (2,'patrimonio adidas' ,'descrição adidas')
INSERT INTO patrimonio (marcaId ,nome, descricao) VALUES (3,'patrimonio microsoft' ,'descrição microsoft')

INSERT INTO usuario (nome, email, senha, role) VALUES('Kakashi', 'kakashi@teste.com','123456' ,'admin')
INSERT INTO usuario (nome, email, senha, role) VALUES('Mario', 'mario@teste.com','123456' ,'gerente')


--SELECT @@SERVERNAME AS 'Server Name'  