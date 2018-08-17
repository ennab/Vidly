namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddingDefualtCities : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Cities Values ('Plano')");
            Sql("Insert into Cities Values ('Frisco')");
            Sql("Insert into Cities Values ('Garland')");
            Sql("Insert into Cities Values ('Richardson')");
        }

        public override void Down()
        {
        }
    }
}
