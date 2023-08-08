using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chatroom.Plugins.EFCore.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "ContactListContactId", "ConversationId", "CreatedAt", "Email", "FirstName", "LastName", "LastUpdatedAt", "Password", "UniqueName" },
                values: new object[] { new Guid("eb0fbf5c-a60a-4ea7-a5e1-a9b58d1a062b"), null, null, new DateTime(2023, 8, 7, 23, 9, 42, 464, DateTimeKind.Local).AddTicks(3151), "joe@gmail.com", "Joe", "Dirt", new DateTime(2023, 8, 7, 23, 9, 42, 464, DateTimeKind.Local).AddTicks(3126), "Password", "JoeDirtie" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("eb0fbf5c-a60a-4ea7-a5e1-a9b58d1a062b"));
        }
    }
}
