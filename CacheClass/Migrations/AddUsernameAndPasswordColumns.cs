using Microsoft.EntityFrameworkCore.Migrations;

public partial class AddUsernameAndPasswordColumns : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "Username",
            table: "Learners",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "Password",
            table: "Learners",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "Username",
            table: "Admins",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "Password",
            table: "Admins",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "Username",
            table: "Instructors",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "Password",
            table: "Instructors",
            nullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Username",
            table: "Learners");

        migrationBuilder.DropColumn(
            name: "Password",
            table: "Learners");

        migrationBuilder.DropColumn(
            name: "Username",
            table: "Admins");

        migrationBuilder.DropColumn(
            name: "Password",
            table: "Admins");

        migrationBuilder.DropColumn(
            name: "Username",
            table: "Instructors");

        migrationBuilder.DropColumn(
            name: "Password",
            table: "Instructors");
    }
}