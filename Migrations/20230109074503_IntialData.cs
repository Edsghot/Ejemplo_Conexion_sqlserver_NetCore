using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace minimalApi.Migrations
{
    /// <inheritdoc />
    public partial class IntialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("a42d2e46-4aab-4fe6-9c3a-44c986106482"), null, "Actividades Personales", 50 },
                    { new Guid("a42d2e46-4aab-4fe6-9c3a-44c98610648c"), null, "Actividades pendientes", 20 }
                });

            migrationBuilder.InsertData(
                table: "tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaConclusion", "FechaCreacion", "PrioridadTarea", "Resumen", "Titulo" },
                values: new object[,]
                {
                    { new Guid("a42d2e46-4aab-4fe6-9c3a-44c986106483"), new Guid("a42d2e46-4aab-4fe6-9c3a-44c986106482"), null, new DateTime(2023, 1, 9, 2, 45, 2, 851, DateTimeKind.Local).AddTicks(6126), new DateTime(2023, 1, 9, 2, 45, 2, 851, DateTimeKind.Local).AddTicks(6101), 1, null, "pago de servicios publicos" },
                    { new Guid("a42d2e46-4aab-4fe6-9c3a-44c986106a81"), new Guid("a42d2e46-4aab-4fe6-9c3a-44c98610648c"), null, new DateTime(2023, 1, 9, 2, 45, 2, 851, DateTimeKind.Local).AddTicks(6195), new DateTime(2023, 1, 9, 2, 45, 2, 851, DateTimeKind.Local).AddTicks(6194), 1, null, "pago de leyendas" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("a42d2e46-4aab-4fe6-9c3a-44c986106483"));

            migrationBuilder.DeleteData(
                table: "tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("a42d2e46-4aab-4fe6-9c3a-44c986106a81"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("a42d2e46-4aab-4fe6-9c3a-44c986106482"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("a42d2e46-4aab-4fe6-9c3a-44c98610648c"));
        }
    }
}
