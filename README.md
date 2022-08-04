 # Linguagem ubíqua

O projeto foi gerado em [.net](https://dotnet.microsoft.com/en-us/download/dotnet/5.0) versao 5.0.

# Para rodar localmente seguir os passos abaixo:
1. Instale o docker
2. abra o prompt de comando e digite: docker pull mongo 
3. apos baixar a imagem via prompt de comando digite o comando: docker run --name mongodb -p 27017:27017 -e MONGO_INITDB_ROOT_USERNAME=ubiqua -e MONGO_INITDB_ROOT_PASSWORD=e296cd9f mongo

# Rodando local

1. Via prompt de comando acesse o diretorio 'ToolBoxDeveloper.DomainContext.MVC' e execute o comando: 'dotnet run'.
2. ao termino do build a aplicação estara disponivel no [endereço https](https://localhost:5001) ou no [endereço http](http://localhost:5000).

