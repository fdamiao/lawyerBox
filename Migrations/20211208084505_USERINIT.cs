using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeblawyersBox.Migrations
{
    public partial class USERINIT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    descricao = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente_Tbs",
                columns: table => new
                {
                    Ids = table.Column<string>(nullable: false),
                    datacreat = table.Column<DateTimeOffset>(nullable: false),
                    Iduser = table.Column<string>(maxLength: 180, nullable: false),
                    responsavel = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(maxLength: 150, nullable: false),
                    apelido = table.Column<string>(maxLength: 50, nullable: true),
                    Ndocumento = table.Column<string>(maxLength: 50, nullable: false),
                    Naturalidade = table.Column<string>(maxLength: 50, nullable: false),
                    Contacto = table.Column<string>(maxLength: 50, nullable: false),
                    Morada = table.Column<string>(maxLength: 50, nullable: false),
                    TipoPessoa = table.Column<string>(maxLength: 50, nullable: false),
                    profissao = table.Column<string>(maxLength: 50, nullable: true),
                    empresa = table.Column<string>(nullable: true),
                    nacionalidade = table.Column<string>(nullable: true),
                    idempresa = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente_Tbs", x => x.Ids);
                });

            migrationBuilder.CreateTable(
                name: "Empresa_Tbs",
                columns: table => new
                {
                    Ids = table.Column<string>(nullable: false),
                    NomeEmpresa = table.Column<string>(maxLength: 150, nullable: false),
                    ContactoTelefone = table.Column<string>(maxLength: 50, nullable: true),
                    EmailEmpresa = table.Column<string>(maxLength: 100, nullable: true),
                    LocalizacaoEmpresa = table.Column<string>(maxLength: 100, nullable: true),
                    LogoTipoEmpresa = table.Column<string>(nullable: true),
                    datefecho = table.Column<DateTime>(type: "date", nullable: true),
                    estado = table.Column<string>(maxLength: 50, nullable: true),
                    caminho = table.Column<string>(nullable: true),
                    datacreat = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa_Tbs", x => x.Ids);
                });

            migrationBuilder.CreateTable(
                name: "licensastbs",
                columns: table => new
                {
                    idlices = table.Column<string>(nullable: false),
                    tipodelicass = table.Column<int>(nullable: false),
                    usuarios = table.Column<int>(nullable: false),
                    honorarios = table.Column<bool>(nullable: false),
                    timeshe = table.Column<bool>(nullable: false),
                    despesa = table.Column<bool>(nullable: false),
                    GB = table.Column<long>(nullable: false),
                    processo = table.Column<int>(nullable: false),
                    datacriacao = table.Column<DateTime>(nullable: false),
                    preco = table.Column<double>(nullable: false),
                    descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_licensastbs", x => x.idlices);
                });

            migrationBuilder.CreateTable(
                name: "TpProcessos",
                columns: table => new
                {
                    Ids = table.Column<string>(nullable: false),
                    datacreat = table.Column<DateTimeOffset>(nullable: false),
                    Iduser = table.Column<string>(maxLength: 180, nullable: false),
                    responsavel = table.Column<string>(nullable: true),
                    rubrica = table.Column<string>(maxLength: 50, nullable: true),
                    descricao = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TpProcessos", x => x.Ids);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    apelido = table.Column<string>(nullable: true),
                    idempresa = table.Column<string>(nullable: true),
                    empresa_TbIds = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Empresa_Tbs_empresa_TbIds",
                        column: x => x.empresa_TbIds,
                        principalTable: "Empresa_Tbs",
                        principalColumn: "Ids",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Processo_Tbs",
                columns: table => new
                {
                    Ids = table.Column<string>(nullable: false),
                    datacreat = table.Column<DateTimeOffset>(nullable: false),
                    Iduser = table.Column<string>(maxLength: 180, nullable: false),
                    responsavel = table.Column<string>(nullable: true),
                    NProcesso = table.Column<string>(maxLength: 50, nullable: false),
                    Observacao = table.Column<string>(maxLength: 250, nullable: true),
                    Objecto = table.Column<string>(maxLength: 250, nullable: true),
                    TituloProcesso = table.Column<string>(maxLength: 200, nullable: false),
                    DataNotificacao = table.Column<DateTime>(type: "date", nullable: true),
                    ValordeCausa = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Valorcondenacao = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    DataDistribuicao = table.Column<DateTime>(type: "date", nullable: true),
                    Fisico = table.Column<string>(maxLength: 50, nullable: true),
                    Estado = table.Column<bool>(nullable: false),
                    Estados = table.Column<int>(nullable: false),
                    Idcliente = table.Column<string>(nullable: true),
                    Cliente_TbIds = table.Column<string>(nullable: true),
                    idempresas = table.Column<string>(nullable: true),
                    Empresa_TbIds = table.Column<string>(nullable: true),
                    instacia = table.Column<int>(nullable: false),
                    tipo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processo_Tbs", x => x.Ids);
                    table.ForeignKey(
                        name: "FK_Processo_Tbs_Cliente_Tbs_Cliente_TbIds",
                        column: x => x.Cliente_TbIds,
                        principalTable: "Cliente_Tbs",
                        principalColumn: "Ids",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Processo_Tbs_Empresa_Tbs_Empresa_TbIds",
                        column: x => x.Empresa_TbIds,
                        principalTable: "Empresa_Tbs",
                        principalColumn: "Ids",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PagamentoLicencas",
                columns: table => new
                {
                    Ids = table.Column<string>(nullable: false),
                    datacreat = table.Column<DateTimeOffset>(nullable: false),
                    Iduser = table.Column<string>(maxLength: 180, nullable: false),
                    responsavel = table.Column<string>(nullable: true),
                    valorpago = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    meses = table.Column<int>(nullable: false),
                    datapagamento = table.Column<DateTime>(nullable: false),
                    comentarios = table.Column<string>(nullable: true),
                    idempresa = table.Column<string>(nullable: true),
                    estadoss = table.Column<int>(nullable: false),
                    Empresa_TbIds = table.Column<string>(nullable: true),
                    idlicensa = table.Column<string>(nullable: true),
                    licensastbsidlices = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagamentoLicencas", x => x.Ids);
                    table.ForeignKey(
                        name: "FK_PagamentoLicencas_Empresa_Tbs_Empresa_TbIds",
                        column: x => x.Empresa_TbIds,
                        principalTable: "Empresa_Tbs",
                        principalColumn: "Ids",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PagamentoLicencas_licensastbs_licensastbsidlices",
                        column: x => x.licensastbsidlices,
                        principalTable: "licensastbs",
                        principalColumn: "idlices",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserClaim<string>",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserClaim<string>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityUserClaim<string>_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActividadesProcessos",
                columns: table => new
                {
                    Ids = table.Column<string>(nullable: false),
                    datacreat = table.Column<DateTimeOffset>(nullable: false),
                    Iduser = table.Column<string>(maxLength: 180, nullable: false),
                    responsavel = table.Column<string>(nullable: true),
                    idprocesso = table.Column<string>(maxLength: 180, nullable: false),
                    Processo_TbIds = table.Column<string>(nullable: true),
                    Descricaoactividades = table.Column<string>(maxLength: 500, nullable: false),
                    data = table.Column<DateTime>(nullable: false),
                    prioridades = table.Column<int>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    cores = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActividadesProcessos", x => x.Ids);
                    table.ForeignKey(
                        name: "FK_ActividadesProcessos_Processo_Tbs_Processo_TbIds",
                        column: x => x.Processo_TbIds,
                        principalTable: "Processo_Tbs",
                        principalColumn: "Ids",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Audiencia_Tabs",
                columns: table => new
                {
                    Ids = table.Column<string>(nullable: false),
                    datacreat = table.Column<DateTimeOffset>(nullable: false),
                    Iduser = table.Column<string>(maxLength: 180, nullable: false),
                    responsavel = table.Column<string>(nullable: true),
                    DataMarcada = table.Column<DateTime>(nullable: false),
                    Datatermino = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<int>(nullable: false),
                    idProcesso = table.Column<string>(nullable: true),
                    evento = table.Column<string>(maxLength: 150, nullable: false),
                    dataCreataud = table.Column<DateTime>(nullable: false),
                    LocaldaAudiencia = table.Column<string>(maxLength: 150, nullable: false),
                    prioridade = table.Column<int>(nullable: false),
                    descricaevento = table.Column<string>(maxLength: 500, nullable: false),
                    cores = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audiencia_Tabs", x => x.Ids);
                    table.ForeignKey(
                        name: "FK_Audiencia_Tabs_Processo_Tbs_idProcesso",
                        column: x => x.idProcesso,
                        principalTable: "Processo_Tbs",
                        principalColumn: "Ids",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CobrancaTBs",
                columns: table => new
                {
                    Ids = table.Column<string>(nullable: false),
                    datacreat = table.Column<DateTimeOffset>(nullable: false),
                    Iduser = table.Column<string>(maxLength: 180, nullable: false),
                    responsavel = table.Column<string>(nullable: true),
                    numero = table.Column<int>(nullable: false),
                    estadoss = table.Column<int>(nullable: false),
                    subtotal = table.Column<double>(nullable: false),
                    Iva = table.Column<double>(nullable: false),
                    Totalgeral = table.Column<double>(nullable: false),
                    desconto = table.Column<double>(nullable: false),
                    consideracoes = table.Column<string>(nullable: true),
                    idprocesso = table.Column<string>(nullable: true),
                    Processo_TbIds = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CobrancaTBs", x => x.Ids);
                    table.ForeignKey(
                        name: "FK_CobrancaTBs_Processo_Tbs_Processo_TbIds",
                        column: x => x.Processo_TbIds,
                        principalTable: "Processo_Tbs",
                        principalColumn: "Ids",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Documentos_Processos_Tbs",
                columns: table => new
                {
                    Ids = table.Column<string>(nullable: false),
                    datacreat = table.Column<DateTimeOffset>(nullable: false),
                    Iduser = table.Column<string>(maxLength: 180, nullable: false),
                    responsavel = table.Column<string>(nullable: true),
                    nomeDoc = table.Column<string>(maxLength: 350, nullable: true),
                    ContentType = table.Column<string>(maxLength: 50, nullable: true),
                    NomeFicheiro = table.Column<string>(maxLength: 500, nullable: true),
                    idProcesso = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentos_Processos_Tbs", x => x.Ids);
                    table.ForeignKey(
                        name: "FK_Documentos_Processos_Tbs_Processo_Tbs_idProcesso",
                        column: x => x.idProcesso,
                        principalTable: "Processo_Tbs",
                        principalColumn: "Ids",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EstatusProcesses",
                columns: table => new
                {
                    Ids = table.Column<string>(nullable: false),
                    datacreat = table.Column<DateTimeOffset>(nullable: false),
                    Iduser = table.Column<string>(maxLength: 180, nullable: false),
                    responsavel = table.Column<string>(nullable: true),
                    status = table.Column<int>(maxLength: 50, nullable: false),
                    descricao = table.Column<string>(maxLength: 250, nullable: false),
                    Idprocesso = table.Column<string>(nullable: true),
                    Processo_TbIds = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstatusProcesses", x => x.Ids);
                    table.ForeignKey(
                        name: "FK_EstatusProcesses_Processo_Tbs_Processo_TbIds",
                        column: x => x.Processo_TbIds,
                        principalTable: "Processo_Tbs",
                        principalColumn: "Ids",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FacturacaoTBs",
                columns: table => new
                {
                    Ids = table.Column<string>(nullable: false),
                    datacreat = table.Column<DateTimeOffset>(nullable: false),
                    Iduser = table.Column<string>(maxLength: 180, nullable: false),
                    responsavel = table.Column<string>(nullable: true),
                    valor = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    descricaoDovalor = table.Column<string>(maxLength: 250, nullable: false),
                    datarecebimento = table.Column<string>(nullable: false),
                    comprovativo = table.Column<string>(nullable: true),
                    tipofacturacao = table.Column<int>(nullable: false),
                    Despesaestatus = table.Column<int>(nullable: false),
                    idprocesso = table.Column<string>(nullable: true),
                    Processo_TbIds = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturacaoTBs", x => x.Ids);
                    table.ForeignKey(
                        name: "FK_FacturacaoTBs_Processo_Tbs_Processo_TbIds",
                        column: x => x.Processo_TbIds,
                        principalTable: "Processo_Tbs",
                        principalColumn: "Ids",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Intrevistas",
                columns: table => new
                {
                    Ids = table.Column<string>(nullable: false),
                    datacreat = table.Column<DateTimeOffset>(nullable: false),
                    Iduser = table.Column<string>(maxLength: 180, nullable: false),
                    responsavel = table.Column<string>(nullable: true),
                    idprocesso = table.Column<string>(nullable: true),
                    Processo_TbIds = table.Column<string>(nullable: true),
                    DescricaoActividade = table.Column<string>(maxLength: 1000, nullable: false),
                    dataConverca = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intrevistas", x => x.Ids);
                    table.ForeignKey(
                        name: "FK_Intrevistas_Processo_Tbs_Processo_TbIds",
                        column: x => x.Processo_TbIds,
                        principalTable: "Processo_Tbs",
                        principalColumn: "Ids",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas_Envolvidas_Tbs",
                columns: table => new
                {
                    Ids = table.Column<string>(nullable: false),
                    datacreat = table.Column<DateTimeOffset>(nullable: false),
                    Iduser = table.Column<string>(maxLength: 180, nullable: false),
                    responsavel = table.Column<string>(nullable: true),
                    idProcesso = table.Column<string>(nullable: true),
                    NomePessoa = table.Column<string>(maxLength: 150, nullable: false),
                    Posicao = table.Column<string>(maxLength: 50, nullable: false),
                    Contacto = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas_Envolvidas_Tbs", x => x.Ids);
                    table.ForeignKey(
                        name: "FK_Pessoas_Envolvidas_Tbs_Processo_Tbs_idProcesso",
                        column: x => x.idProcesso,
                        principalTable: "Processo_Tbs",
                        principalColumn: "Ids",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimesheetTbs",
                columns: table => new
                {
                    Ids = table.Column<string>(nullable: false),
                    datacreat = table.Column<DateTimeOffset>(nullable: false),
                    Iduser = table.Column<string>(maxLength: 180, nullable: false),
                    responsavel = table.Column<string>(nullable: true),
                    idprocesso = table.Column<string>(nullable: true),
                    Processo_TbIds = table.Column<string>(nullable: true),
                    datarealisada = table.Column<DateTime>(nullable: false),
                    horasrealizadas = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    descricadashoras = table.Column<string>(maxLength: 250, nullable: false),
                    cargo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimesheetTbs", x => x.Ids);
                    table.ForeignKey(
                        name: "FK_TimesheetTbs_Processo_Tbs_Processo_TbIds",
                        column: x => x.Processo_TbIds,
                        principalTable: "Processo_Tbs",
                        principalColumn: "Ids",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalhesCobrancas",
                columns: table => new
                {
                    Iddetalhes = table.Column<string>(nullable: false),
                    descricao = table.Column<string>(maxLength: 200, nullable: false),
                    Qty = table.Column<double>(nullable: false),
                    precoUnit = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    precTotal = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    idcobranca = table.Column<string>(nullable: true),
                    CobrancaTBIds = table.Column<string>(nullable: true),
                    dataregistro = table.Column<DateTime>(nullable: false),
                    iduser = table.Column<string>(nullable: true),
                    idprocesso = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalhesCobrancas", x => x.Iddetalhes);
                    table.ForeignKey(
                        name: "FK_DetalhesCobrancas_CobrancaTBs_CobrancaTBIds",
                        column: x => x.CobrancaTBIds,
                        principalTable: "CobrancaTBs",
                        principalColumn: "Ids",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActividadesProcessos_Processo_TbIds",
                table: "ActividadesProcessos",
                column: "Processo_TbIds");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_empresa_TbIds",
                table: "AspNetUsers",
                column: "empresa_TbIds");

            migrationBuilder.CreateIndex(
                name: "IX_Audiencia_Tabs_idProcesso",
                table: "Audiencia_Tabs",
                column: "idProcesso");

            migrationBuilder.CreateIndex(
                name: "IX_CobrancaTBs_Processo_TbIds",
                table: "CobrancaTBs",
                column: "Processo_TbIds");

            migrationBuilder.CreateIndex(
                name: "IX_DetalhesCobrancas_CobrancaTBIds",
                table: "DetalhesCobrancas",
                column: "CobrancaTBIds");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_Processos_Tbs_idProcesso",
                table: "Documentos_Processos_Tbs",
                column: "idProcesso");

            migrationBuilder.CreateIndex(
                name: "IX_EstatusProcesses_Processo_TbIds",
                table: "EstatusProcesses",
                column: "Processo_TbIds");

            migrationBuilder.CreateIndex(
                name: "IX_FacturacaoTBs_Processo_TbIds",
                table: "FacturacaoTBs",
                column: "Processo_TbIds");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserClaim<string>_ApplicationUserId",
                table: "IdentityUserClaim<string>",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Intrevistas_Processo_TbIds",
                table: "Intrevistas",
                column: "Processo_TbIds");

            migrationBuilder.CreateIndex(
                name: "IX_PagamentoLicencas_Empresa_TbIds",
                table: "PagamentoLicencas",
                column: "Empresa_TbIds");

            migrationBuilder.CreateIndex(
                name: "IX_PagamentoLicencas_licensastbsidlices",
                table: "PagamentoLicencas",
                column: "licensastbsidlices");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_Envolvidas_Tbs_idProcesso",
                table: "Pessoas_Envolvidas_Tbs",
                column: "idProcesso");

            migrationBuilder.CreateIndex(
                name: "IX_Processo_Tbs_Cliente_TbIds",
                table: "Processo_Tbs",
                column: "Cliente_TbIds");

            migrationBuilder.CreateIndex(
                name: "IX_Processo_Tbs_Empresa_TbIds",
                table: "Processo_Tbs",
                column: "Empresa_TbIds");

            migrationBuilder.CreateIndex(
                name: "IX_TimesheetTbs_Processo_TbIds",
                table: "TimesheetTbs",
                column: "Processo_TbIds");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActividadesProcessos");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Audiencia_Tabs");

            migrationBuilder.DropTable(
                name: "DetalhesCobrancas");

            migrationBuilder.DropTable(
                name: "Documentos_Processos_Tbs");

            migrationBuilder.DropTable(
                name: "EstatusProcesses");

            migrationBuilder.DropTable(
                name: "FacturacaoTBs");

            migrationBuilder.DropTable(
                name: "IdentityUserClaim<string>");

            migrationBuilder.DropTable(
                name: "Intrevistas");

            migrationBuilder.DropTable(
                name: "PagamentoLicencas");

            migrationBuilder.DropTable(
                name: "Pessoas_Envolvidas_Tbs");

            migrationBuilder.DropTable(
                name: "TimesheetTbs");

            migrationBuilder.DropTable(
                name: "TpProcessos");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "CobrancaTBs");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "licensastbs");

            migrationBuilder.DropTable(
                name: "Processo_Tbs");

            migrationBuilder.DropTable(
                name: "Cliente_Tbs");

            migrationBuilder.DropTable(
                name: "Empresa_Tbs");
        }
    }
}
