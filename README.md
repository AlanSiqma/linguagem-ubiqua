 # Linguagem ubíqua
O que é?
Linguagem Ubíqua (ou Linguagem Onipresente) é um conceito central de DDD. Ela consiste de um conjunto de termos que devem ser plenamente entendidos tanto por especialistas no domínio (usuários do sistema) como por desenvolvedores (implementadores do sistema)

O projeto visa o gerenciamento da linguagem ubíqua das empresas, facilitando assim o entendimento da regra de negocio.

Gerado em [.net](https://dotnet.microsoft.com/en-us/download/dotnet/5.0) versao 5.0

# Pré requesito
Mongo DB

# Rodando mongo via Docker:
1. Instale o docker
2. abra o prompt de comando e digite: docker pull mongo 
3. apos baixar a imagem via prompt de comando digite o comando: docker run --name mongodb -p 27017:27017 -e MONGO_INITDB_ROOT_USERNAME=ubiqua -e MONGO_INITDB_ROOT_PASSWORD=e296cd9f mongo

# Rodando Aplicação localmente

1. Via prompt de comando acesse o diretorio 'ToolBoxDeveloper.DomainContext.MVC' e execute o comando: 'dotnet run'.
2. ao termino do build a aplicação estara disponivel no [endereço https](https://localhost:5001) ou no [endereço http](http://localhost:5000).

