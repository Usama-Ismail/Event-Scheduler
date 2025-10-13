using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_Scheduler.Api.Migrations;

/// <inheritdoc />
public partial class Hangfire_Migration : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("CREATE DATABASE HangfireDb");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {

    }
}
