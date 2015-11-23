# WebApplication1

<p>
    <strong>TECNOLOGIAS E FERRAMENTAS</strong><br />
    Visual Studio 2015 Community<br />
    ASP.NET 5 (Built-in IoC Container)<br />
    ASP.NET MVC 6<br />
    Entity Framework (com Code-First Approach)<br />
    Angular JS<br />
    Bootstrap<br />
    NPM<br />
    Bower<br />
    Gulp<br />
    <br />
    <strong>INSTRUÇÕES</strong><br />
    A aplicação contém um service-base database file, mas pode ser utilizado um banco de dados Sql Server real. Basta atualizar a string de conexão no arquivo config.json.<br />
    No caso de utilização com o arquivo de banco de dados que está no projeto, nenhuma alteração é necessária. Contudo, deve-se saber que cada vez que rodar a aplicação no Visual Studio, ele vai zerar o banco de dados.<br />
    <br />
    <strong>OBSERVAÇÕES</strong><br />    
    1 - Ao carregar a solution no Visual Studio 2015, é necessário aguardar um tempo para que o NPM e o Bower instale as dependências. O progresso pode ser visto no Output. Se as dependências não forem instaladas correntamente, a aplicação não vai funcionar porque os arquivos são colocados na pasta root via tarefa Gulp.<br />
    2 - Se quando a solution for carregada, o nó "References" do projeto WepApplication1 não estiver com o subnó DNX, é necessário clicar com o direito nesse projeto e dá um unload-reload. Não sei a causa disso, mas eu sempre faço esse procedimento e funciona :D Eu sempre espero a instalação das dependências para poder executar esse passo.<br />
</p>