using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrdemServico.Api.Migrations
{
    /// <inheritdoc />
    public partial class create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Situacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Situacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoOrdem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoOrdem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoPessoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPessoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoProduto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProduto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CpfCnpj = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Contato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoId = table.Column<int>(type: "int", nullable: false),
                    SituacaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => new { x.Id, x.CpfCnpj });
                    table.ForeignKey(
                        name: "FK_Pessoa_Situacao_SituacaoId",
                        column: x => x.SituacaoId,
                        principalTable: "Situacao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pessoa_TipoPessoa_TipoId",
                        column: x => x.TipoId,
                        principalTable: "TipoPessoa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoId = table.Column<int>(type: "int", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SituacaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_Situacao_SituacaoId",
                        column: x => x.SituacaoId,
                        principalTable: "Situacao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Produto_TipoProduto_TipoId",
                        column: x => x.TipoId,
                        principalTable: "TipoProduto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ordem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorLiquido = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ValorBruto = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    QuantidadeProduto = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Desconto = table.Column<int>(type: "int", nullable: true),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroControle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ClienteCpfCnpj = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SituacaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ordem_Pessoa_ClienteId_ClienteCpfCnpj",
                        columns: x => new { x.ClienteId, x.ClienteCpfCnpj },
                        principalTable: "Pessoa",
                        principalColumns: new[] { "Id", "CpfCnpj" });
                    table.ForeignKey(
                        name: "FK_Ordem_Situacao_SituacaoId",
                        column: x => x.SituacaoId,
                        principalTable: "Situacao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ordem_TipoOrdem_TipoId",
                        column: x => x.TipoId,
                        principalTable: "TipoOrdem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicoOrdem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sequencial = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    OrdemId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SituacaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicoOrdem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicoOrdem_Ordem_OrdemId",
                        column: x => x.OrdemId,
                        principalTable: "Ordem",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServicoOrdem_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServicoOrdem_Situacao_SituacaoId",
                        column: x => x.SituacaoId,
                        principalTable: "Situacao",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Situacao",
                columns: new[] { "Id", "Codigo", "Icone", "Nome", "Observacao" },
                values: new object[,]
                {
                    { 1, 1, null, "Cadastrado", null },
                    { 2, 2, null, "Ag modificação", null },
                    { 3, 3, null, "Ag aprovação", null },
                    { 4, 4, null, "Ativo", null },
                    { 5, 5, null, "Cancelado", null }
                });

            migrationBuilder.InsertData(
                table: "TipoOrdem",
                columns: new[] { "Id", "Codigo", "Nome", "Observacao" },
                values: new object[,]
                {
                    { 1, 1, "Manutenção", null },
                    { 2, 2, "Compra", null },
                    { 3, 3, "Venda", null }
                });

            migrationBuilder.InsertData(
                table: "TipoPessoa",
                columns: new[] { "Id", "Codigo", "Nome", "Observacao" },
                values: new object[,]
                {
                    { 1, 1, "Física", null },
                    { 2, 2, "Jurídica", null },
                    { 3, 3, "Outro", null }
                });

            migrationBuilder.InsertData(
                table: "TipoProduto",
                columns: new[] { "Id", "Codigo", "Nome", "Observacao" },
                values: new object[,]
                {
                    { 1, 1, "Próprio", null },
                    { 2, 2, "Terceiro", null },
                    { 3, 3, "Mão de obra", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ordem_ClienteId_ClienteCpfCnpj",
                table: "Ordem",
                columns: new[] { "ClienteId", "ClienteCpfCnpj" });

            migrationBuilder.CreateIndex(
                name: "IX_Ordem_Codigo",
                table: "Ordem",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ordem_SituacaoId",
                table: "Ordem",
                column: "SituacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordem_TipoId",
                table: "Ordem",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_Codigo",
                table: "Pessoa",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_SituacaoId",
                table: "Pessoa",
                column: "SituacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_TipoId",
                table: "Pessoa",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_Codigo",
                table: "Produto",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_SituacaoId",
                table: "Produto",
                column: "SituacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_TipoId",
                table: "Produto",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicoOrdem_OrdemId",
                table: "ServicoOrdem",
                column: "OrdemId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicoOrdem_ProdutoId",
                table: "ServicoOrdem",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicoOrdem_SituacaoId",
                table: "ServicoOrdem",
                column: "SituacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Situacao_Codigo",
                table: "Situacao",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoOrdem_Codigo",
                table: "TipoOrdem",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoPessoa_Codigo",
                table: "TipoPessoa",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoProduto_Codigo",
                table: "TipoProduto",
                column: "Codigo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServicoOrdem");

            migrationBuilder.DropTable(
                name: "Ordem");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "TipoOrdem");

            migrationBuilder.DropTable(
                name: "TipoProduto");

            migrationBuilder.DropTable(
                name: "Situacao");

            migrationBuilder.DropTable(
                name: "TipoPessoa");
        }
    }
}
