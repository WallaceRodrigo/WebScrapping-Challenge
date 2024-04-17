# Projeto WebScrapping TBCA

## Visão Geral do Projeto
O projeto WebScrapping TBCA é uma aplicação web desenvolvida para extrair dados do site TBCA.net.br e exibi-los em uma interface de usuário amigável. A aplicação permite aos usuários visualizar informações sobre alimentos, incluindo seus componentes nutricionais.

## Tecnologias Utilizadas
### Backend
- **FluentAssertions.AspNetCore.MVC:** Utilizado para testes de integração.
- **HtmlAgilityPack:** Utilizado para fazer o parsing do HTML e extrair os dados do site TBCA.net.br.
- **Microsoft.AspNetCore.Cors:** Utilizado para habilitar a política de CORS na aplicação.
- **Microsoft.EntityFrameworkCore:** Utilizado para acesso e manipulação de dados no banco de dados.
- **Microsoft.EntityFrameworkCore.Design:** Utilizado para a geração de migrações e execução de comandos relacionados ao EF Core.
- **Microsoft.EntityFrameworkCore.SqlServer:** Utilizado como provedor de banco de dados SQL Server para o EF Core.
- **Microsoft.EntityFrameworkCore.Tools:** Utilizado para a execução de comandos do EF Core no Visual Studio.
- **Swashbuckle.AspNetCore:** Utilizado para a geração da documentação da API com o Swagger.

### Frontend
- **React:** Biblioteca JavaScript utilizada para construir a interface de usuário.
- **react-axios:** Utilizado para fazer requisições HTTP no frontend.
- **react-bootstrap:** Framework front-end utilizado para construir componentes de interface de usuário.
- **react-router-dom:** Utilizado para navegação entre páginas na aplicação React.

### Banco de Dados
- **SQL Server:** Utilizado como banco de dados para armazenar os dados extraídos do site TBCA.net.br.
- **Entity Framework Core:** Utilizado para mapeamento objeto-relacional (ORM) e operações de banco de dados no SQL Server.
- **LINQ (Language-Integrated Query):** Utilizado para escrever consultas em C# e interagir com o banco de dados.

### Containização
- **Docker:** Utilizado para criar, implantar e executar aplicativos em contêineres.
- **Docker Compose:** Utilizado para definir e executar aplicativos multicontêineres. No contexto deste projeto, é utilizado para orquestrar o contêiner do banco de dados Azure SQL Server juntamente com o contêiner da aplicação.

## Instruções de Instalação e Uso
1. **Backend:**
   - Clone o repositório do projeto.
   - Navegue até a pasta `BackEnd`.
   - Certifique-se de ter o `SDK do .NET Core 6.0` instalado em seu sistema.
   - Certifique-se de ter a ferramenta dotnet-ef intalada `dotnet tool install --global dotnet-ef`
     em caso do erro "Não foi possível executar porque o comando ou o arquivo especificado não foi encontrado":
     ```shell
     export PATH="$PATH:/home/{seuUser}/.dotnet/tools"
     ```
  
   O banco de dados, deverá ser iniciado com o comando:
   ```shell
   docker-compose up -d --build
   ```
   
   Para conectar ao seu sistema de gerenciamento de banco de dados, utilize as seguintes credenciais:
   - `Server`: localhost
   - `User`: sa
   - `Password`: Password123
   - `Trust server certificate`: true

   Ou a connection string:
   `"Server=localhost;Database=WebScrappingDB;User=SA;Password=Password123;TrustServerCertificate=True"`

   As migrations devem ser aplicadas para subir a DataBase antes da API com:
   ```shell
   dotnet ef database update
   ```
   
   - Execute o comando `dotnet run` para iniciar o servidor backend.
   - O servidor backend estará acessível em `https://localhost:7070`.

3. **Frontend:**
   - Certifique-se de ter o `Node.js` instalado em seu sistema.
   - Navegue até a pasta `FrontEnd`.
   - Execute o comando `npm install` para instalar as dependências do projeto.
   - Execute o comando `npm start` para iniciar o servidor de desenvolvimento do React.
   - O aplicativo estará acessível em `http://localhost:3000`.

## Descrição das Funcionalidades
- **Extrair Alimentos:** Na página inicial, é possível inserir o número da página desejada do site TBCA.net.br e extrair os alimentos dessa página.
- **Pesquisar Alimentos:** Também é possível pesquisar por alimentos específicos digitando o nome do alimento na barra de pesquisa.
Contribuição

## Descrição das Técnicas Utilizadas
- **Web Scraping:** O backend utiliza a biblioteca HtmlAgilityPack para fazer o scraping do site TBCA.net.br e extrair os dados relacionados aos alimentos.
- **API RESTful:** O backend expõe endpoints RESTful para que o frontend possa interagir com os dados.
- **React Hooks:** O frontend utiliza React Hooks para gerenciar o estado e os efeitos colaterais da aplicação de forma mais eficiente.
- **Roteamento com React Router:** O frontend utiliza o React Router para criar rotas na aplicação e permitir a navegação entre diferentes páginas.
- **Entity Framework Core e LINQ:** Utilizados para realizar operações de banco de dados, como consulta, inserção, atualização e exclusão, no SQL Server.
- **Docker e Docker Compose:** Utilizados para containerizar a aplicação e definir a infraestrutura de contêineres, incluindo o contêiner do banco de dados Azure SQL Server.
