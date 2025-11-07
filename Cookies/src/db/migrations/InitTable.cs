using FluentMigrator;

namespace Economy.Database.Migrations;

[Migration(1762471031)]
public class InitTable : Migration
{
    public override void Up()
    {
        Create.Table("PlayerCookies")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("SteamId64").AsInt64().NotNullable()
            .WithColumn("Data").AsFixedLengthString(16384).NotNullable().WithDefaultValue("{}");
    }

    public override void Down()
    {
        Delete.Table("PlayerCookies");
    }
}