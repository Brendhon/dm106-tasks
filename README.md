<h1 align="center">DM106 - Tasks</h1>

---

## ❓ Sobre o projeto

Este projeto da disciplina DM106 (Desenvolvimento de Web Services com segurança sob plataforma .NET) tem como objetivo criar uma API REST para gerenciar tarefas.

Para isso, foi utilizado o framework .NET Core 7.0, Azure SQL e a Azure Cloud para hospedar a API.

---

## 💻 Tecnologias

As seguintes tecnologias foram utilizadas na construção do projeto:

 - **[.NET Core 7.0](https://dotnet.microsoft.com/download/dotnet/7.0)**
 - **[Azure SQL](https://azure.microsoft.com/pt-br/services/sql-database/)**
 - **[Azure Cloud](https://azure.microsoft.com/pt-br/)**
 - **[Swagger](https://swagger.io/)**

> Para mais detalhes, veja o arquivo  **[Tasks.csproj](Tasks.csproj)**

### Utilitários
- Editor:  **[Visual Studio Code](https://code.visualstudio.com/)**

---
## ⚙️ Como executar o projeto

### 💡 Pré-requisitos

Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:
**[Git](https://git-scm.com)** e **[.NET](https://dotnet.microsoft.com/download/dotnet/7.0)**; 

```bash

# Clone este repositório
$ git clone https://github.com/Brendhon/dm106-tasks.git

# Acesse a pasta do projeto

# Limpe o projeto
$ dotnet clean

# Build da aplicação
$ dotnet build

```
### ⚽ Rodando no modo desenvolvedor

```bash

# Execute a aplicação
$ dotnet run

# Iniciará na porta:500

```

---


## 📝 Documentação
Após executar a aplicação, acesse a documentação da API em: **[http://localhost:5000/swagger/index.html](http://localhost:5000/swagger/index.html)**


---

## Comandos úteis

```bash

# Criar migration
$ dotnet ef migrations add <nome da migration> --context <nome do contexto>

# Atualizar banco de dados
$ dotnet ef database update

# Atualizar banco de dados no Azure com base no local
$ dotnet ef database update --connection "<your-azure-sql-connection-string>" --context TaskContext

```

## 👥 Autor
<h4 align="left">
<img style="border-radius: 5%; margin-right: 30px" src="https://avatars.githubusercontent.com/Brendhon" width="120px;" alt="Avatar"/><br>
Brendhon Moreira
</h4>


[![Linkedin Badge](https://img.shields.io/badge/-Brendhon-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/brendhon-moreira)](https://www.linkedin.com/in/brendhon-moreira)
[![Gmail Badge](https://img.shields.io/badge/-brendhon.e.c.m@gmail.com-c14438?style=flat-square&logo=Gmail&logoColor=white&link=mailto:brendhon.e.c.m@gmail.com)](mailto:brendhon.e.c.m@gmail.com)

---
## 📝 License
[![License](https://img.shields.io/github/license/Brendhon/Pokedex?style=plastic)](http://badges.mit-license.org)

- **[MIT license](https://choosealicense.com/licenses/mit/)**
