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
