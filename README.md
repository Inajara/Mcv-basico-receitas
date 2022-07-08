# Desafio de MVC

### Descrição
Desafio de MCV com o objetivo de simular uma página de receitas.

### Passo a passo:
Antes de inicialixar a aplicação, pede-se que se importe dados para teste. 
Para isso, basta importar os arquivos .csv da pasta Importaç~es via Wizard Import do MySql Workbench

Após realizar as imporações, usar o comando dotnet watch run.
Com isso, cairá na página de login.

Cadastrar o seguinte:
 -Admin; email: admin@gft.com; senha Gft@1234
 Esse cadastro é obrigatório para acessar as configurações do sistema
Após esse passo, pode cadastrar usuário aleatório para fins de checagem do controle de acesso.

Não foi utilizada uma metodologia de cadastro tradicional dos grandes sites, restringindo o uso de javascript.
Foi abrodada uma ideia incomum de cadastro de receitas, onde pode-se cadastrar listas de conjuntos de ingredientes e medidas específicos de cada receita.

A opção de omissão foi substituida pela remoção, mas pode ser adicionada eventualmente sem prejuízos.

A página de visualização de usuário apresentou bugs de última hora.

O CRUD funciona sem problemas, mas foram necessários muitos ajustes de rotas em comparação com a maioria das videoaulas da pasta e da internet.