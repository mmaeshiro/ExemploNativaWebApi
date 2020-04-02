------CONFIGURAÇÃO-----
Foi criado uma WebApi Padrão MVC com asp .net core entityFremeworkCore e autenticação JwtBearer

- Banco de dados SQL SERVE 2017 e SQL SERVE MANAGEMENT STUDIO V18.4
-Crie uma Base dados com esse nome LaboratorioDB
-Gere o script
 ScriptBancoDadosNativa.sql

***VISUAL STUDIO 2019 APLICATION WEB ASP .NET Core 3.1***
- Microsofit.EntityFrameworkCore 3.1.3 (package)
- Microsofit.EntityFrameworkCore.SqlServer 3.1.3 (package)
- Microsoft.AspNetCore.Authorization 2.2.0 (package)
- Microsoft.AspNetCore.Authentication.JwtBearer 3.1.3 (package)

--appsettings.json--
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
 "AllowedHosts": "*",
  "ConnectionStrings": {
    "NativacConexao": "Server=Seu_Serve_Nome;Database=LaboratorioDB;User Id=sa;Password=Sua-Senha;"
  }
}
--- WEB API ------------------------------------------------------------------
***PARAMETROS HEADERS TOKEN POSTMAN AUTENTICAÇÃO ***
Chave: Authorization  
Valor: Bearer SEUTOKEN

*USUARIO***************************************************************************
Mudar A URL para da sua maquina (https://localhost:44381) Quando da o play no projeto

AUTENTICAR OBTER TOKEN = Tipo POST, https://localhost:44381/api//Usuario/login

JSON OBJETO MODELO1 
{
   "email": "kakashi@teste.com",
   "senha": "123456"
}
retorno 
sucesso =
{
  "usuarioId": 1,
  "nome": "Kakashi",
  "email": "kakashi@teste.com",
  "senha": "123456",
  "role": "admin"
},
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFkbWluc3RyYWRvciIsIm5iZiI6MTU4NTcxNjIwNSwiZXhwIjoxNTg1NzIzNDA1LCJpYXQiOjE1ODU3MTYyMDV9.wMNfrIpVK7jo7jnOZckylHJ63r9llqNqQfOprNPAmt8"
}
erro = "Usuário ou senha inválidos"
-----------------------------------------------------------------------------
OBTERTODOS = Tipo GET, https://localhost:44381/api/Usuario/ObterTodos 
[Authorize(Roles = "admin,gerente")]
    {
        "usuarioId": 1,
        "nome": "Kakashi",
        "email": "kakashi@teste.com",
        "senha": "123456",
        "role": "admin"
    },
    {
        "usuarioId": 2,
        "nome": "Mario",
        "email": "mario@teste.com",
        "senha": "123456",
        "role": "gerente"
    }
]
------------------------------------------------------------------------------
ADICIONAR = Tipo POST, https://localhost:44381/api/Usuario/Adicionar
[Authorize(Roles = "admin,gerente")]
JSON OBJETO MODELO 
{
  "nome": "Teste	",
  "email": "teste@teste.com",
  "senha":"123456",
  "role":"funcionario"
 }
retorno retorno sucesso sucesso, erro Já existe essa e-mail cadastrado , exeção Ocorreu uma falhar cadastrado usuário
------------------------------------------------------------------------------
EDITAR= Tipo PUT, https://localhost:44381/api/Usuario/Editar
[Authorize(Roles = "admin,gerente")]
JSON OBJETO MODELO 
{
	"usuarioId": 1,
	"nome": "Adminstrador",
	"email": "teste1@teste.com",
	"senha": "123456"
}
retorno retorno sucesso sucesso, erro Já existe essa e-mail cadastrado , exeção Ocorreu uma falhar cadastrada usuário
-------------------------------------------------------------------------------
OBTERTODOS = Tipo DELETE https://localhost:44381/api/Usuario/Excluir/2(idUsuario)
[Authorize(Roles = "admin")]

*PATROCINIO***************************************************************************
Mudar A URL para da sua maquina (https://localhost:44381) Quando da o play no projeto

OBTERTODOS = Tipo GET, https://localhost:44381/api/Patrimonio/ObterTodos
[Authorize(Roles = "admin,gerente")]
------------------------------------------------------------------------------
ADICIONAR = Tipo POST, https://localhost:44381/api/Patrimonio/Adicionar
[Authorize(Roles = "admin,gerente")]
JSON OBJETO MODELO 
{
 "marcaId":1,
 "nome":"nome patrimonio nike 3",
 "descricao":"descricao patrimonio nike 3"
 }
retorno sucesso true, erro false
------------------------------------------------------------------------------
EDITAR= Tipo PUT, https://localhost:44381/api/Patrimonio/Editar
[Authorize(Roles = "admin,gerente")]
JSON OBJETO MODELO 
{
"numeroTombo":1,
 "marcaId":1,
 "nome":"nome patrimonio nike editar",
 "descricao":"descricao patrimonio editar"
 }
retorno retorno sucesso sucesso, erro Já existe essa marca cadastrada , exeção Ocorreu uma falhar cadastrada Patrocionio
-------------------------------------------------------------------------------
OBTERTODOS = Tipo DELETE https://localhost:44381/api/Patrimonio/Excluir/1(numeroTombo)
[Authorize(Roles = "admin")]

*MARCA*************************************************************************
OBTERTODOS = Tipo GET, https://localhost:44381/api/Marca/ObterTodos
[Authorize(Roles = "admin,gerente,funcionario")]
------------------------------------------------------------------------------
ADICIONAR = Tipo POST, https://localhost:44381/api/Marca/Adicionar
[Authorize(Roles = "admin,gerente")]
JSON OBJETO MODELO 
{
    "nome": "Nativa"
}
retorno sucesso true, erro false
------------------------------------------------------------------------------
EDITAR= Tipo PUT, https://localhost:44381/api/Marca/Editar
[Authorize(Roles = "admin,gerente")]
JSON OBJETO MODELO 
{
 "marcaId":1,
 "nome":".Net"
 }
retorno sucesso sucesso, erro Já existe essa marca cadastrada , exeção Ocorreu uma falhar cadastrada marca




 

