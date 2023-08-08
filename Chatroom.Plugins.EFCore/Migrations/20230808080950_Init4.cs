using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chatroom.Plugins.EFCore.Migrations
{
    public partial class Init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ContactList",
                columns: new[] { "ContactId", "UserContact", "UserId" },
                values: new object[,]
                {
                    { 1, new Guid("7bccb0ba-0050-4f69-9312-906436dda76f"), new Guid("eb0fbf5c-a60a-4ea7-a5e1-a9b58d1a062b") },
                    { 2, new Guid("eb0fbf5c-a60a-4ea7-a5e1-a9b58d1a062b"), new Guid("7bccb0ba-0050-4f69-9312-906436dda76f") }
                });

            migrationBuilder.InsertData(
                table: "Conversation",
                columns: new[] { "ConversationId", "RecipientUser", "StartedUser" },
                values: new object[] { 1, new Guid("7bccb0ba-0050-4f69-9312-906436dda76f"), new Guid("eb0fbf5c-a60a-4ea7-a5e1-a9b58d1a062b") });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("7bccb0ba-0050-4f69-9312-906436dda76f"),
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2023, 8, 8, 10, 9, 50, 518, DateTimeKind.Local).AddTicks(6417), new DateTime(2023, 8, 8, 10, 9, 50, 518, DateTimeKind.Local).AddTicks(6414) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("eb0fbf5c-a60a-4ea7-a5e1-a9b58d1a062b"),
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2023, 8, 8, 10, 9, 50, 518, DateTimeKind.Local).AddTicks(6412), new DateTime(2023, 8, 8, 10, 9, 50, 518, DateTimeKind.Local).AddTicks(6393) });

            migrationBuilder.InsertData(
                table: "Message",
                columns: new[] { "MessageId", "Context", "ConversationId", "Created", "UserId" },
                values: new object[] { 1, "Hi, There!", 1, new DateTime(2023, 8, 8, 10, 9, 50, 518, DateTimeKind.Local).AddTicks(6590), new Guid("eb0fbf5c-a60a-4ea7-a5e1-a9b58d1a062b") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactList",
                keyColumn: "ContactId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ContactList",
                keyColumn: "ContactId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Message",
                keyColumn: "MessageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Conversation",
                keyColumn: "ConversationId",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("7bccb0ba-0050-4f69-9312-906436dda76f"),
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2023, 8, 8, 8, 56, 12, 562, DateTimeKind.Local).AddTicks(6923), new DateTime(2023, 8, 8, 8, 56, 12, 562, DateTimeKind.Local).AddTicks(6845) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("eb0fbf5c-a60a-4ea7-a5e1-a9b58d1a062b"),
                columns: new[] { "CreatedAt", "LastUpdatedAt" },
                values: new object[] { new DateTime(2023, 8, 8, 8, 56, 12, 562, DateTimeKind.Local).AddTicks(6843), new DateTime(2023, 8, 8, 8, 56, 12, 562, DateTimeKind.Local).AddTicks(6829) });
        }
    }
}
