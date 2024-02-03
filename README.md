## Data Annotatios - Atributos de Validação do modelo

```System.ComponentModel.DataAnnotations```<br>
```System.ComponentModel.DataAnnotations.Schema```

São atributos que podem ser aplicados a classes e seus membros para realizar as seguintes tarefas:
- Definir regras de validação para o modelo
- Definir como os dados devem ser exibidos na interface
- Especificar o relacionamento entre entidades de modelo
- Sobreescrever as convenções padrão do Entity Framework Core
  
Pode ser usado para validação de dados tanto no front-end como back-end. É importante também para quando é feita a migração do modelo, por exemplo, dito umm length para campo a migração entenderá o tamanho exato do varchar a ser definido para o banco.

## Migrations
Quando criadas as migrações dos Models é criado os arquivos de migrações dentro da Pasta Migrations, dentros desses arquivos existem dois métodos, Up e Down, O Up contém as instruções para quando a migração é executada e o Down tem as instruções reversas as alterações feitos no Up.

## Injeção de Dependência
A injeção de dependência ajuda a manter o baixo acoplamento entre classes concretas
<a href="https://www.macoratti.net/19/04/c_dioc1.htm#:~:text=Este%20recurso%20permite%20a%20inje%C3%A7%C3%A3o,ser%20independente%20dos%20seus%20objetos.">Site para melhor detalhes</a>

## Erro na migração
Estava ocorrendo um erro na migração e descobri pesquisando na internet que esse erro provém da string de conexão
#### Erro:
```
ClientConnectionId:fe600924-5466-4a67-b57c-3a8bcc662660 Error Number:-2146893019,State:0,Class:20 A connection was successfully established with the server, but then an error occurred during the login process. (provider: SSL Provider, error: 0 - A cadeia de certificação foi emitida por uma autoridade que não é de confiança.)
```
Então bastou eu passar mais um parâmetro para string de conexão ```TrustServerCeritificate=True```

#### String de conexão:
```
"DefaultConnection": "Data Source=DESKTOP-VLUVVKE\\SQLEXPRESS; Initial Catalog=LanchesDatabase; Trusted_Connection=True; TrustServerCertificate=True"
```

## View fortemente tipada
Eu não entendia muito bem o porque de passar uma coleção de objetos para uma view e na view ter que declarar novamente uma coleção para iterar sobre ela
#### Contoller:
```
 public IActionResult List()
 {
     var lanches = _lancheRepository.Lanches;
     return View(lanches);
 }
```
## View
```
@model IEnumerable<LanchesMac.Models.Lanche>


<div><h2>Todos os Lanches</h2></div>

@foreach (var lanche in Model)
{
    <div>
        <h2>Lanche: @lanche.Nome</h2>
        <p><img src="@lanche.ImageUrl" width="100px" height="100px"/></p>
        <p>Preço: @lanche.Preco.ToString("c")</p>
    </div>
}

```
Por algumas pesquisas creio que essa forma de tipar fortemente a coleção seja eficaz para a view reconhecer os objetos da coleção e o intellisense agir 


## ViewData
Transfere dadis do Controller para a View; é do tipo ViewDataDictionary. É um dicionário que armazena dados no formato chave/valor. Exige a conversão de tipos para: verificar valores nulos, obter dados, evitar erros.

```
//Controller
ViewData["Titulo"] = "Todos os lanches";
ViewData["Data"] = Data Time.Now;

//View
@ViewData["Titulo"]
@ViewData["Data"]
```

## ViewBag 
transfere dados do Controller para View; é uma proprieade dinâmica (dynamic). É um tipo object que armazena dados no formato chave/valor. Não requer a conversão de tipos.

```
//Controller
ViewBag.Total = "Total de lanches:";
ViewBag.TotalLanches = lanches.Count();

//View
@ViewBag.Total
@ViewBag.TotalLanches
```

## TempData
Transfere dados do :Controller para a View, da View para o Controller ou de métodos Action para outro método Action no mesmo Controlador ou para um Controlador diferente. É um objeto dicionário do tipo TempDataDictionary que armazena dados do formato chave/valor. Armazena os dados temporariamente e os remove automaticamente após recuperar um valor. Exige conversão de tipos.

```
//Controller1
TempData["Nome"] = "Lucas";

//Controller2
@TempData["Nome"]
```
## Importância dos arquivos _ViewStart e _ViewImports
- _ViewStart: ele define o layout comum a todas as views, caso uma view em questão não queria usar o layout definido no _ViewStart basta definir ```@{ Layout = null }``` no início do arquivo
- _ViewImports: define os namespaces que poderão ser usados nas Views: ```@using LanchesMac.Models```, dessa forma as Views poderão acessar os models do projeto.

## ViewModel
### Definição
É um padrão de projeto que permite separar as responsaabilidades do modelo de domínio dos modelos que atendem as Views.
Representa o conjunto de uma ou mais entidades do Modelo de domínio e de outras informações que serão exibidas em uma View.

1. Contém apenas as proprieades que serão representadas na View.
2. Pode possuir regras específicas de validação (Data Annotations).
3. Pode conter múltiplas entidades ou objetos dos modelo de domínio.
4. Contém a lógica da interface do usuário.
5. Contém somente dedos e comportamentos relacionados às Views.

<img src="https://github.com/LucasNithael/lanchesMac-MVC-aspnet/assets/94084548/ef13b022-d2ef-41b3-9f40-fe0829b7f64a" width="400px" />

### Utilização
- Gerenciar ou criar listas suspensas para uma entidade.
- Criar View MestreDetalhes.
- Usadas em carrinhos de compras.
- Usadas em paginação de dados.
- Usadas para implementar o Login e o Registro.
