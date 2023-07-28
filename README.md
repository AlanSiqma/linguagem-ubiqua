# O QUE É LINGUAGEM UBÍQUA?
Linguagem Ubíqua (ou Linguagem Onipresente) é um conceito central de DDD. Ela consiste de um conjunto de termos que devem ser plenamente entendidos tanto por especialistas no domínio (usuários do sistema) como por desenvolvedores (implementadores do sistema)

# O PROJETO

Visa o gerenciamento da linguagem ubíqua das empresas, facilitando assim o entendimento da regra de negocio.

Gerado em [.net](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) versao 6.0

Você pode acessar a aplicação pelo [link](https://www.linguagemubiqua.devtoolkit.com.br/)
## ENTRE NO SLACK

https://join.slack.com/t/devtoolkit/shared_invite/zt-20h6komuo-n2bhRcti4XwZj0wOvTH6bg

### LÁ NO SLACK

- Se apresente. Nome, cidade, profissão, e principais habilidades.
- Pergunte sobre as tarefas em aberto.
- Troque uma ideia com o time técnico. Comente como planeja solucionar. Ouça os conselhos dos devs mais experientes. Esse alinhamento é super importante pra aumentar significativamente as chances do seu PULL REQUEST ser aprovado depois.

## FAÇA PARTE DA EQUIPE NO TRELLO

https://trello.com/invite/b/IfvGZ5HL/ATTIcaeaa16b4e30e28c7352b533956194ec081451E2/ubiquitous-language

</br>

### PEGUE UMA TAREFA NO TRELLO.

- https://trello.com/b/IfvGZ5HL/ubiquitous-language
- Coloque no seu nome e mova para DOING.

</br>

##  GITHUB

- FAÇA UM FORK DO REPOSITÓRIO: https://github.com/AlanSiqma/linguagem-ubiqua
- Crie uma branch baseada na branch original `develop`
    (experimente: `git checkout develop && git checkout -b nomeDaSuaNovaBranch`)
- Escreva seu código
    **Nota:** Não esqueça de garantir que todos os testes unitários continuem sendo executados corretamente.
- Crie sua PR apontando para a branch base `develop`
- Aguarde/acompanhe o status do seu PR
- Compartilhe/convide um amigo para contribuir

</br>

<h1 style="text-align: center;">---> MISSÃO CUMPRIDA ✈️ <---</h1>


## RODANDO APLICAÇÃO LOCALMENTE

## PRÉ REQUESITO
Mongo DB

### RODANDO MONGO VIA DOCKER:
- Instale o [docker](https://docs.docker.com/engine/install/)
- Abra o prompt de comando e digite: docker pull mongo 
- Apos baixar a imagem via prompt de comando digite o comando: docker run --name mongodb -p 27017:27017 -e MONGO_INITDB_ROOT_USERNAME=ubiqua -e MONGO_INITDB_ROOT_PASSWORD=e296cd9f mongo

### RODANDO APLICAÇÃO
- Via prompt de comando acesse o diretorio 'ToolBoxDeveloper.DomainContext.MVC' e execute o comando: 'dotnet run'.
- Ao termino do build a aplicação estara disponivel no [endereço https](https://localhost:5001) ou no [endereço http](http://localhost:5000).
