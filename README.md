<h1 align="center">
    Task Manager API 
</h1>
<p align="center">🚀 Uma Api para gerenciar um Lista de Tarefas</p>

### 🛠 Features

As seguintes ferramentas foram usadas na construção do projeto:

- [Git](https://git-scm.com)
- [.NET](https://dotnet.microsoft.com/pt-br/download/dotnet/thank-you/sdk-8.0.303-windows-x64-installer?journey=vs-code)
- [Docker](https://www.docker.com/products/docker-desktop/)
- [Visual Studio Code](https://code.visualstudio.com/download)
- [PostgreSQL](https://www.postgresql.org/download/)
- [Make](https://gnuwin32.sourceforge.net/packages/make.htm)

As seguintes extensões do VsCode foram usadas no desenvolvimento: 

- [C#](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
- [C# dev kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)
- [IntelliCode for C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.vscodeintellicode-csharp)
- [.NET Extension Pack](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.vscode-dotnet-pack)

Em desenvolvimento foi instalado os pacotes a seguir:

- `dotnet add package Microsoft.EntityFrameworkCore`
- `dotnet add package Microsoft.EntityFrameworkCore.SqlServer`
- `dotnet add package Microsoft.EntityFrameworkCore.Design`
- `dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL`
- `dotnet add package Swashbuckle.AspNetCore`
- `dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson`

### ✅ Pré-requisitos

Antes de começar, é preciso que você tenha instalado as ferramentas acima e algumas é preciso ter uma atenção especial:<br />
- No caso do [PostgreSQL](https://www.postgresql.org/download/) é preciso configurar usuário e senha para poder acessar o servidor de dentro da Api.<br />
- Já o [Make](https://gnuwin32.sourceforge.net/packages/make.htm) é preciso editar as variáveis de ambiente do seu computador e adicionar o Make como variável de sistema dentro do Path para que assim voce possa utilizá-lo via Cmd.<br />

Os demais basta seguir o passo a passo de instalação na documentação disponizada.<br />

### Getting Started

- Clone o repositório em sua máquina: `git clone https://github.com/julianoferrrone12/TaskManagerAPI.git` <br />
- Na pasta em que foi clonado o repositório acesse o diretório correto: "cd TaskManagerAPI".
- No arquivo "appsettings.json" altere a string de conexão DefaultConnection adicionando o seu usuario e senha do Postgres para fazer a conexão com o servidor e salve as alterações.
- Altere também no arquivo "docker-compose.yml" o usuário e senha do Postgres e salve as alterações.
- Agora basta rodar o comando `make infra-local` que os containers do docker com sua Api e banco de dados estará rodando
- Clique para acessar o [Swagger](http://localhost:8081/swagger/index.html) e utilizar a Api.

## 🚩 The End

🌟Antes de sair desse repositório não esqueça de deixar sua "star" ajuda muito e não custa nada!! 🌟
