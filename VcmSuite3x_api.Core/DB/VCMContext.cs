using System;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;


namespace VcmSuite3x_api.Core.Models
{
    public partial class VCMContext : DbContext
    {
        #region Constructors
        public VCMContext()
        {

        }

        public VCMContext(DbContextOptions<VCMContext> options)
            : base(options)
        {
        }
        #endregion

        #region Properties Db Sets
        public virtual DbSet<Agenda> Agenda { get; set; }
        public virtual DbSet<AgendaOtimizacao> AgendaOtimizacao { get; set; }
        public virtual DbSet<Application> Application { get; set; }
        public virtual DbSet<ApplicationHistory> ApplicationHistory { get; set; }
        public virtual DbSet<ArmazenamentoCenario> ArmazenamentoCenario { get; set; }
        public virtual DbSet<Blend> Blend { get; set; }
        public virtual DbSet<Cadeia> Cadeia { get; set; }
        public virtual DbSet<Calculo> Calculo { get; set; }
        public virtual DbSet<CalculoHistorico> CalculoHistorico { get; set; }
        public virtual DbSet<Cenario> Cenario { get; set; }
        public virtual DbSet<Conjunto> Conjunto { get; set; }
        public virtual DbSet<ConjuntoEntidade> ConjuntoEntidade { get; set; }
        public virtual DbSet<ConjuntoFarinha> ConjuntoFarinha { get; set; }
        public virtual DbSet<ConjuntoFarinhaProduto> ConjuntoFarinhaProduto { get; set; }
        public virtual DbSet<ConjuntoProduto> ConjuntoProduto { get; set; }
        public virtual DbSet<Contrato> Contrato { get; set; }
        public virtual DbSet<CoresAddIn> CoresAddIn { get; set; }
        public virtual DbSet<Corrente> Corrente { get; set; }
        public virtual DbSet<CorrenteCenario> CorrenteCenario { get; set; }
        public virtual DbSet<CorrenteCenarioLimite> CorrenteCenarioLimite { get; set; }
        public virtual DbSet<CorrenteCenarioSimbolo> CorrenteCenarioSimbolo { get; set; }
        public virtual DbSet<CorrenteDrawing> CorrenteDrawing { get; set; }
        public virtual DbSet<CorrenteFamilia> CorrenteFamilia { get; set; }
        public virtual DbSet<CorrenteProduto> CorrenteProduto { get; set; }
        public virtual DbSet<Desconto> Desconto { get; set; }
        public virtual DbSet<DiagramaCenario> DiagramaCenario { get; set; }
        public virtual DbSet<DivisorCenario> DivisorCenario { get; set; }
        public virtual DbSet<ElementoTipoProduto> ElementoTipoProduto { get; set; }
        public virtual DbSet<EntidadeSimbolo> EntidadeSimbolo { get; set; }
        public virtual DbSet<Entrada> Entrada { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<FaixaCustoFixo> FaixaCustoFixo { get; set; }
        public virtual DbSet<FaixaDesconto> FaixaDesconto { get; set; }
        public virtual DbSet<Familia> Familia { get; set; }
        public virtual DbSet<FamiliaContrato> FamiliaContrato { get; set; }
        public virtual DbSet<FluxogramaDrawing> FluxogramaDrawing { get; set; }
        public virtual DbSet<FornecimentoCenario> FornecimentoCenario { get; set; }
        public virtual DbSet<FuncaoObjetivo> FuncaoObjetivo { get; set; }
        public virtual DbSet<LabelPadraoTopologia> LabelPadraoTopologia { get; set; }
        public virtual DbSet<Limite> Limite { get; set; }
        public virtual DbSet<MedidaCadeia> MedidaCadeia { get; set; }
        public virtual DbSet<MedidaProjeto> MedidaProjeto { get; set; }
        public virtual DbSet<MercadoCenario> MercadoCenario { get; set; }
        public virtual DbSet<MercadoContrato> MercadoContrato { get; set; }
        public virtual DbSet<Modal> Modal { get; set; }
        public virtual DbSet<No> No { get; set; }
        public virtual DbSet<NoCenarioFaixaCustoFixo> NoCenarioFaixaCustoFixo { get; set; }
        public virtual DbSet<NoCenarioLimite> NoCenarioLimite { get; set; }
        public virtual DbSet<NoCenarioSimbolo> NoCenarioSimbolo { get; set; }
        public virtual DbSet<NoDrawing> NoDrawing { get; set; }
        public virtual DbSet<NoFamilia> NoFamilia { get; set; }
        public virtual DbSet<NoProduto> NoProduto { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<Periodo> Periodo { get; set; }
        public virtual DbSet<PeriodoAgregado> PeriodoAgregado { get; set; }
        public virtual DbSet<PeriodoAgregadoItem> PeriodoAgregadoItem { get; set; }
        public virtual DbSet<PeriodoCenario> PeriodoCenario { get; set; }
        public virtual DbSet<PortaDrawing> PortaDrawing { get; set; }
        public virtual DbSet<PortoCenario> PortoCenario { get; set; }
        public virtual DbSet<PrecoBase> PrecoBase { get; set; }
        public virtual DbSet<ProcessamentoCenario> ProcessamentoCenario { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<ProdutoCenarioSimbolo> ProdutoCenarioSimbolo { get; set; }
        public virtual DbSet<ProdutoContrato> ProdutoContrato { get; set; }
        public virtual DbSet<ProdutoFamilia> ProdutoFamilia { get; set; }
        public virtual DbSet<Projeto> Projeto { get; set; }
        public virtual DbSet<Propriedade> Propriedade { get; set; }
        public virtual DbSet<PropriedadeAgrupamento> PropriedadeAgrupamento { get; set; }
        public virtual DbSet<PropriedadeProduto> PropriedadeProduto { get; set; }
        public virtual DbSet<PropriedadeTopologia> PropriedadeTopologia { get; set; }
        public virtual DbSet<Regiao> Regiao { get; set; }
        public virtual DbSet<Restricao> Restricao { get; set; }
        public virtual DbSet<RestricaoCenario> RestricaoCenario { get; set; }
        public virtual DbSet<RestricaoCorrente> RestricaoCorrente { get; set; }
        public virtual DbSet<RestricaoNo> RestricaoNo { get; set; }
        public virtual DbSet<Resultado> Resultado { get; set; }
        public virtual DbSet<Silo> Silo { get; set; }
        public virtual DbSet<Simbolo> Simbolo { get; set; }
        public virtual DbSet<SituacaoCalculo> SituacaoCalculo { get; set; }
        public virtual DbSet<TemplateMedida> TemplateMedida { get; set; }
        public virtual DbSet<TipoArmazenamento> TipoArmazenamento { get; set; }
        public virtual DbSet<TipoDemanda> TipoDemanda { get; set; }
        public virtual DbSet<TipoDivisor> TipoDivisor { get; set; }
        public virtual DbSet<TipoEntidade> TipoEntidade { get; set; }
        public virtual DbSet<TipoLimite> TipoLimite { get; set; }
        public virtual DbSet<TipoLimiteCorrente> TipoLimiteCorrente { get; set; }
        public virtual DbSet<TipoProduto> TipoProduto { get; set; }
        public virtual DbSet<TipoPropriedade> TipoPropriedade { get; set; }
        public virtual DbSet<TipoRestricao> TipoRestricao { get; set; }
        public virtual DbSet<TipoUnidade> TipoUnidade { get; set; }
        public virtual DbSet<TipoValor> TipoValor { get; set; }
        public virtual DbSet<Topologia> Topologia { get; set; }
        public virtual DbSet<UnidadeComposta> UnidadeComposta { get; set; }
        public virtual DbSet<UnidadeFederacao> UnidadeFederacao { get; set; }
        public virtual DbSet<UnidadeMedida> UnidadeMedida { get; set; }
        public virtual DbSet<UnificadorCenario> UnificadorCenario { get; set; }
        public virtual DbSet<Valvula> Valvula { get; set; }
        #endregion

        #region Configuring and Creating Model
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

                string conn = config.GetConnectionString("DBVCM");

                optionsBuilder.UseSqlServer(conn, sqlServerOptions => sqlServerOptions.CommandTimeout(300));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Agenda>(entity =>
            {
                entity.HasIndex(e => e.Nome)
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nota)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AgendaOtimizacao>(entity =>
            {
                entity.HasKey(e => new { e.CenarioId, e.AgendaId, e.Sequencia });

                entity.HasIndex(e => new { e.AgendaId, e.CenarioId })
                    .HasName("IX_AgendaOtimizacao_AgendaIdCenarioId")
                    .IsUnique();

                entity.HasIndex(e => new { e.AgendaId, e.Sequencia })
                    .HasName("IX_AgendaOtimizacao_AgendaIdSequencia")
                    .IsUnique();

                entity.HasOne(d => d.Agenda)
                    .WithMany(p => p.AgendaOtimizacao)
                    .HasForeignKey(d => d.AgendaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AgendaOtimizacao_Agenda");

                entity.HasOne(d => d.Cenario)
                    .WithMany(p => p.AgendaOtimizacao)
                    .HasForeignKey(d => d.CenarioId)
                    .HasConstraintName("FK_AgendaOtimizacao_Cenario");
            });


            modelBuilder.Entity<Application>(entity =>
            {
                entity.Property(e => e.Address)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ApiKey)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ApiSecretKey)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ApiToken)
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.ApiTokenCreated).HasColumnType("datetime");

                entity.Property(e => e.ApiTokenExpireOn).HasColumnType("datetime");

                entity.Property(e => e.City)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ContactEmail)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ContactName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPhone)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailPreferences)
                    .IsRequired()
                    .HasMaxLength(2056)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ApplicationHistory>(entity =>
            {
                entity.Property(e => e.CallerIpAddress)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.CallerMethod)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.CallerUrl)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.Registered).HasColumnType("datetime");

                entity.Property(e => e.RegisteredBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.ReturnInternalMessage)
                    .IsRequired()
                    .HasMaxLength(1024);
            });

            modelBuilder.Entity<ArmazenamentoCenario>(entity =>
            {
                entity.HasKey(e => new { e.NoId, e.CenarioId });

                entity.HasIndex(e => e.TipoArmazenamentoId)
                    .HasName("IX_FK_TipoArmazenamentoArmazenamentoCenario");

                entity.Property(e => e.Capex)
                    .HasColumnName("CAPEX")
                    .HasColumnType("decimal(38, 13)");

                entity.HasOne(d => d.Cenario)
                    .WithMany(p => p.ArmazenamentoCenario)
                    .HasForeignKey(d => d.CenarioId)
                    .HasConstraintName("FK_CenarioArmazenamentoCenario");

                entity.HasOne(d => d.No)
                    .WithMany(p => p.ArmazenamentoCenario)
                    .HasForeignKey(d => d.NoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_NoArmazenamentoCenario");

                entity.HasOne(d => d.TipoArmazenamento)
                    .WithMany(p => p.ArmazenamentoCenario)
                    .HasForeignKey(d => d.TipoArmazenamentoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoArmazenamentoArmazenamentoCenario");
            });

            modelBuilder.Entity<Blend>(entity =>
            {
                entity.HasIndex(e => e.TipoEntidadeId)
                    .HasName("IX_FK_TipoEntidadeBlend");

                entity.HasIndex(e => e.TopologiaId)
                    .HasName("IX_FK_TopologiaBlend");

                entity.HasIndex(e => new { e.TopologiaId, e.Codigo })
                    .HasName("IX_Blend_TopologiaIdCodigo")
                    .IsUnique();

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipoEntidade)
                    .WithMany(p => p.Blend)
                    .HasForeignKey(d => d.TipoEntidadeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoEntidadeBlend");

                entity.HasOne(d => d.Topologia)
                    .WithMany(p => p.Blend)
                    .HasForeignKey(d => d.TopologiaId)
                    .HasConstraintName("FK_TopologiaBlend");
            });

            modelBuilder.Entity<Cadeia>(entity =>
            {
                entity.HasIndex(e => e.Nome)
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Calculo>(entity =>
            {
                entity.HasIndex(e => e.CenarioId)
                    .HasName("IX_FK_CenarioCalculo");

                entity.HasOne(d => d.Cenario)
                    .WithMany(p => p.Calculo)
                    .HasForeignKey(d => d.CenarioId)
                    .HasConstraintName("FK_CenarioCalculo");
            });

            modelBuilder.Entity<CalculoHistorico>(entity =>
            {
                entity.HasKey(e => new { e.CalculoId, e.SituacaoCalculoId });

                entity.Property(e => e.Nota)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Calculo)
                    .WithMany(p => p.CalculoHistorico)
                    .HasForeignKey(d => d.CalculoId)
                    .HasConstraintName("FK_CalculoHistorico_Calculo");

                entity.HasOne(d => d.SituacaoCalculo)
                    .WithMany(p => p.CalculoHistorico)
                    .HasForeignKey(d => d.SituacaoCalculoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CalculoHistorico_SituacaoCalculo");
            });

            modelBuilder.Entity<Cenario>(entity =>
            {
                entity.HasIndex(e => e.TopologiaId)
                    .HasName("IX_FK_TopologiaCenario");

                entity.HasIndex(e => new { e.TopologiaId, e.Nome })
                    .HasName("IX_Cenario_TopologiaIdNome")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Topologia)
                    .WithMany(p => p.Cenario)
                    .HasForeignKey(d => d.TopologiaId)
                    .HasConstraintName("FK_TopologiaCenario");
            });

            modelBuilder.Entity<Conjunto>(entity =>
            {
                entity.HasIndex(e => e.TipoEntidadeId)
                    .HasName("IX_FK_TipoEntidadeConjunto");

                entity.HasIndex(e => e.TopologiaId)
                    .HasName("IX_FK_TopologiaConjunto");

                entity.HasIndex(e => new { e.TopologiaId, e.Codigo })
                    .HasName("IX_Conjunto_TopologiaIdNome")
                    .IsUnique();

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipoEntidade)
                    .WithMany(p => p.Conjunto)
                    .HasForeignKey(d => d.TipoEntidadeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoEntidadeConjunto");

                entity.HasOne(d => d.Topologia)
                    .WithMany(p => p.Conjunto)
                    .HasForeignKey(d => d.TopologiaId)
                    .HasConstraintName("FK_TopologiaConjunto");
            });

            modelBuilder.Entity<ConjuntoEntidade>(entity =>
            {
                entity.HasKey(e => new { e.TipoConjuntoId, e.TipoEntidadeId });

                entity.HasOne(d => d.TipoConjunto)
                    .WithMany(p => p.ConjuntoEntidadeTipoConjunto)
                    .HasForeignKey(d => d.TipoConjuntoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ConjuntoEntidadeTipoConjunto");

                entity.HasOne(d => d.TipoEntidade)
                    .WithMany(p => p.ConjuntoEntidadeTipoEntidade)
                    .HasForeignKey(d => d.TipoEntidadeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ConjuntoEntidadeTipoEntidade");
            });

            modelBuilder.Entity<ConjuntoFarinha>(entity =>
            {
                entity.HasIndex(e => e.ConjuntoId)
                    .HasName("IX_FK_ConjuntoConjuntoFarinha");

                entity.HasIndex(e => e.TipoEntidadeId)
                    .HasName("IX_FK_TipoEntidadeConjuntoFarinha");

                entity.HasIndex(e => e.TopologiaId)
                    .HasName("IX_FK_TopologiaConjuntoFarinha");

                entity.HasIndex(e => new { e.TopologiaId, e.Codigo })
                    .HasName("IX_ConjuntoFarinha_TopologiaIdCodigo")
                    .IsUnique();

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.Conjunto)
                    .WithMany(p => p.ConjuntoFarinha)
                    .HasForeignKey(d => d.ConjuntoId)
                    .HasConstraintName("FK_ConjuntoConjuntoFarinha");

                entity.HasOne(d => d.TipoEntidade)
                    .WithMany(p => p.ConjuntoFarinha)
                    .HasForeignKey(d => d.TipoEntidadeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoEntidadeConjuntoFarinha");

                entity.HasOne(d => d.Topologia)
                    .WithMany(p => p.ConjuntoFarinha)
                    .HasForeignKey(d => d.TopologiaId)
                    .HasConstraintName("FK_TopologiaConjuntoFarinha");
            });

            modelBuilder.Entity<ConjuntoFarinhaProduto>(entity =>
            {
                entity.HasKey(e => new { e.ProdutoId, e.ConjuntoFarinhaId });

                entity.HasIndex(e => e.ConjuntoFarinhaId)
                    .HasName("IX_FK_ConjuntoFarinhaConjuntoFarinhaProduto");

                entity.HasIndex(e => e.ProdutoId)
                    .HasName("IX_FK_ProdutoConjuntoFarinhaProduto");

                entity.HasOne(d => d.ConjuntoFarinha)
                    .WithMany(p => p.ConjuntoFarinhaProduto)
                    .HasForeignKey(d => d.ConjuntoFarinhaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ConjuntoFarinhaConjuntoFarinhaProduto");

                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.ConjuntoFarinhaProduto)
                    .HasForeignKey(d => d.ProdutoId)
                    .HasConstraintName("FK_ProdutoConjuntoFarinhaProduto");
            });

            modelBuilder.Entity<ConjuntoProduto>(entity =>
            {
                entity.HasKey(e => new { e.ConjuntoId, e.ProdutoId });

                entity.HasOne(d => d.Conjunto)
                    .WithMany(p => p.ConjuntoProduto)
                    .HasForeignKey(d => d.ConjuntoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ConjuntoProdutoConjunto");

                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.ConjuntoProduto)
                    .HasForeignKey(d => d.ProdutoId)
                    .HasConstraintName("FK_ConjuntoProdutoProduto");
            });

            modelBuilder.Entity<Contrato>(entity =>
            {
                entity.HasIndex(e => e.TipoEntidadeId)
                    .HasName("IX_FK_TipoEntidadeContrato");

                entity.HasIndex(e => e.TipoProdutoId)
                    .HasName("IX_FK_TipoProdutoContrato");

                entity.HasIndex(e => e.TopologiaId)
                    .HasName("IX_FK_TopologiaContrato");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipoEntidade)
                    .WithMany(p => p.Contrato)
                    .HasForeignKey(d => d.TipoEntidadeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoEntidadeContrato");

                entity.HasOne(d => d.TipoProduto)
                    .WithMany(p => p.Contrato)
                    .HasForeignKey(d => d.TipoProdutoId)
                    .HasConstraintName("FK_TipoProdutoContrato");

                entity.HasOne(d => d.Topologia)
                    .WithMany(p => p.Contrato)
                    .HasForeignKey(d => d.TopologiaId)
                    .HasConstraintName("FK_TopologiaContrato");
            });

            modelBuilder.Entity<CoresAddIn>(entity =>
            {
                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Corrente>(entity =>
            {
                entity.HasIndex(e => e.EntradaId)
                    .HasName("IX_FK_NoEntradaCorrente");

                entity.HasIndex(e => e.ModalId)
                    .HasName("IX_FK_ModalCorrente");

                entity.HasIndex(e => e.SaidaId)
                    .HasName("IX_FK_NoSaidaCorrente");

                entity.HasIndex(e => e.TipoEntidadeId)
                    .HasName("IX_FK_TipoEntidadeCorrente");

                entity.HasIndex(e => e.TopologiaId)
                    .HasName("IX_FK_TopologiaCorrente");

                entity.HasIndex(e => new { e.TopologiaId, e.Codigo })
                    .HasName("IX_Corrente_TopologiaIdCodigo")
                    .IsUnique();

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Nota)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.ContratoTakeOrPay)
                    .WithMany(p => p.Corrente)
                    .HasForeignKey(d => d.ContratoTakeOrPayId)
                    .HasConstraintName("FK_ContratoTakeOrPay");

                entity.HasOne(d => d.Desconto)
                    .WithMany(p => p.Corrente)
                    .HasForeignKey(d => d.DescontoId)
                    .HasConstraintName("FK_DescontoCorrente");

                entity.HasOne(d => d.Entrada)
                    .WithMany(p => p.CorrenteEntrada)
                    .HasForeignKey(d => d.EntradaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_NoEntradaCorrente");

                entity.HasOne(d => d.Modal)
                    .WithMany(p => p.Corrente)
                    .HasForeignKey(d => d.ModalId)
                    .HasConstraintName("FK_ModalCorrente");

                entity.HasOne(d => d.Saida)
                    .WithMany(p => p.CorrenteSaida)
                    .HasForeignKey(d => d.SaidaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_NoSaidaCorrente");

                entity.HasOne(d => d.TipoEntidade)
                    .WithMany(p => p.Corrente)
                    .HasForeignKey(d => d.TipoEntidadeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoEntidadeCorrente");

                entity.HasOne(d => d.Topologia)
                    .WithMany(p => p.Corrente)
                    .HasForeignKey(d => d.TopologiaId)
                    .HasConstraintName("FK_TopologiaCorrente");
            });

            modelBuilder.Entity<CorrenteCenario>(entity =>
            {
                entity.HasKey(e => new { e.CorrenteId, e.CenarioId });

                entity.HasIndex(e => e.ContratoTakeOrPayId)
                    .HasName("IX_FK_ContratoTakeOrPayCorrenteCenario");

                entity.HasIndex(e => e.TipoLimiteCorrenteId)
                    .HasName("IX_FK_TipoLimiteCorrente");

                entity.Property(e => e.TipoLimiteCorrenteId).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Cenario)
                    .WithMany(p => p.CorrenteCenario)
                    .HasForeignKey(d => d.CenarioId)
                    .HasConstraintName("FK_CenarioCorrenteCenario");

                entity.HasOne(d => d.Corrente)
                    .WithMany(p => p.CorrenteCenario)
                    .HasForeignKey(d => d.CorrenteId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CorrenteCorrenteCenario");

                entity.HasOne(d => d.TipoLimiteCorrente)
                    .WithMany(p => p.CorrenteCenario)
                    .HasForeignKey(d => d.TipoLimiteCorrenteId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoLimiteCorrente");
            });

            modelBuilder.Entity<CorrenteCenarioLimite>(entity =>
            {
                entity.HasKey(e => new { e.CorrenteId, e.CenarioId });

                entity.Property(e => e.LimiteMaximoFamiliaTotal)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LimiteMaximoProdutoTotal)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LimiteMinimoFamiliaTotal)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LimiteMinimoProdutoTotal)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Cenario)
                    .WithMany(p => p.CorrenteCenarioLimite)
                    .HasForeignKey(d => d.CenarioId)
                    .HasConstraintName("FK_CenarioCorrenteCenarioLimite");

                entity.HasOne(d => d.Corrente)
                    .WithMany(p => p.CorrenteCenarioLimite)
                    .HasForeignKey(d => d.CorrenteId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CorrenteCorrenteCenarioLimite");
            });

            modelBuilder.Entity<CorrenteCenarioSimbolo>(entity =>
            {
                entity.HasKey(e => new { e.CorrenteId, e.CenarioId, e.SimboloId });

                entity.Property(e => e.Detalhado).HasDefaultValueSql("((1))");

                entity.Property(e => e.ValorExato).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Cenario)
                    .WithMany(p => p.CorrenteCenarioSimbolo)
                    .HasForeignKey(d => d.CenarioId)
                    .HasConstraintName("FK_CorrenteCenarioSimboloCenario");

                entity.HasOne(d => d.Corrente)
                    .WithMany(p => p.CorrenteCenarioSimbolo)
                    .HasForeignKey(d => d.CorrenteId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CorrenteCenarioSimboloCorrente");

                entity.HasOne(d => d.Simbolo)
                    .WithMany(p => p.CorrenteCenarioSimbolo)
                    .HasForeignKey(d => d.SimboloId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CorrenteCenarioSimboloSimbolo");
            });

            modelBuilder.Entity<CorrenteDrawing>(entity =>
            {
                entity.HasKey(e => new { e.FluxogramaId, e.CorrenteId });

                entity.HasIndex(e => e.FluxogramaId)
                    .HasName("IX_FK_FluxogramaCorrenteDrawing");

                entity.HasIndex(e => e.PortaEntradaId)
                    .HasName("IX_FK_PortaDrawingCorrenteDrawingEntrada");

                entity.HasIndex(e => e.PortaSaidaId)
                    .HasName("IX_FK_PortaDrawingCorrenteDrawingSaida");

                entity.HasOne(d => d.Corrente)
                    .WithMany(p => p.CorrenteDrawing)
                    .HasForeignKey(d => d.CorrenteId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CorrenteCorrenteDrawing");

                entity.HasOne(d => d.Fluxograma)
                    .WithMany(p => p.CorrenteDrawing)
                    .HasForeignKey(d => d.FluxogramaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_FluxogramaCorrenteDrawing");

                entity.HasOne(d => d.PortaEntrada)
                    .WithMany(p => p.CorrenteDrawingPortaEntrada)
                    .HasForeignKey(d => d.PortaEntradaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PortaDrawingCorrenteDrawingEntrada");

                entity.HasOne(d => d.PortaSaida)
                    .WithMany(p => p.CorrenteDrawingPortaSaida)
                    .HasForeignKey(d => d.PortaSaidaId)
                    .HasConstraintName("FK_PortaDrawingCorrenteDrawingSaida");
            });

            modelBuilder.Entity<CorrenteFamilia>(entity =>
            {
                entity.HasKey(e => new { e.CorrenteId, e.FamiliaId });

                entity.HasOne(d => d.Corrente)
                    .WithMany(p => p.CorrenteFamilia)
                    .HasForeignKey(d => d.CorrenteId)
                    .HasConstraintName("FK_CorrenteFamiliaCorrente");

                entity.HasOne(d => d.Familia)
                    .WithMany(p => p.CorrenteFamilia)
                    .HasForeignKey(d => d.FamiliaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CorrenteFamiliaFamilia");
            });

            modelBuilder.Entity<CorrenteProduto>(entity =>
            {
                entity.HasKey(e => new { e.CorrenteId, e.ProdutoId });

                entity.HasOne(d => d.Corrente)
                    .WithMany(p => p.CorrenteProduto)
                    .HasForeignKey(d => d.CorrenteId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CorrenteProdutoCorrente");

                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.CorrenteProduto)
                    .HasForeignKey(d => d.ProdutoId)
                    .HasConstraintName("FK_CorrenteProdutoProduto");
            });

            modelBuilder.Entity<Desconto>(entity =>
            {
                entity.HasIndex(e => e.ModalId)
                    .HasName("IX_FK_ModalDesconto");

                entity.HasIndex(e => e.TipoEntidadeId)
                    .HasName("IX_FK_TipoEntidadeDesconto");

                entity.HasIndex(e => e.TipoUnidadeId)
                    .HasName("IX_FK_TipoUnidadeDesconto");

                entity.HasIndex(e => e.TopologiaId)
                    .HasName("IX_FK_TopologiaDesconto");

                entity.HasIndex(e => new { e.TopologiaId, e.Codigo })
                    .HasName("IX_Desconto_TopologiaIdCodigo")
                    .IsUnique();

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.Modal)
                    .WithMany(p => p.Desconto)
                    .HasForeignKey(d => d.ModalId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ModalDesconto");

                entity.HasOne(d => d.TipoEntidade)
                    .WithMany(p => p.Desconto)
                    .HasForeignKey(d => d.TipoEntidadeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoEntidadeDesconto");

                entity.HasOne(d => d.TipoUnidade)
                    .WithMany(p => p.Desconto)
                    .HasForeignKey(d => d.TipoUnidadeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoUnidadeDesconto");

                entity.HasOne(d => d.Topologia)
                    .WithMany(p => p.Desconto)
                    .HasForeignKey(d => d.TopologiaId)
                    .HasConstraintName("FK_TopologiaDesconto");
            });

            modelBuilder.Entity<DiagramaCenario>(entity =>
            {
                entity.HasKey(e => new { e.NoId, e.CenarioId });

                entity.HasIndex(e => e.ConjuntoId)
                    .HasName("IX_FK_ConjuntoDiagramaCenario");

                entity.HasIndex(e => e.TransportadorFareloId)
                    .HasName("IX_FK_CorrenteFareloDiagramaCenario");

                entity.HasIndex(e => e.TransportadorRemoidoId)
                    .HasName("IX_FK_CorrenteRemoidoDiagramaCenario");

                entity.HasIndex(e => e.ValvulaFareloId)
                    .HasName("IX_FK_ValvulaFareloDiagramaCenario");

                entity.HasIndex(e => e.ValvulaRemoidoId)
                    .HasName("IX_FK_ValvulaRemoidoDiagramaCenario");

                entity.HasOne(d => d.Cenario)
                    .WithMany(p => p.DiagramaCenario)
                    .HasForeignKey(d => d.CenarioId)
                    .HasConstraintName("FK_CenarioDiagramaCenario");

                entity.HasOne(d => d.Conjunto)
                    .WithMany(p => p.DiagramaCenario)
                    .HasForeignKey(d => d.ConjuntoId)
                    .HasConstraintName("FK_ConjuntoDiagramaCenario");

                entity.HasOne(d => d.No)
                    .WithMany(p => p.DiagramaCenario)
                    .HasForeignKey(d => d.NoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_NoDiagramaCenario");

                entity.HasOne(d => d.TransportadorFarelo)
                    .WithMany(p => p.DiagramaCenarioTransportadorFarelo)
                    .HasForeignKey(d => d.TransportadorFareloId)
                    .HasConstraintName("FK_CorrenteFareloDiagramaCenario");

                entity.HasOne(d => d.TransportadorRemoido)
                    .WithMany(p => p.DiagramaCenarioTransportadorRemoido)
                    .HasForeignKey(d => d.TransportadorRemoidoId)
                    .HasConstraintName("FK_CorrenteRemoidoDiagramaCenario");

                entity.HasOne(d => d.ValvulaFarelo)
                    .WithMany(p => p.DiagramaCenarioValvulaFarelo)
                    .HasForeignKey(d => d.ValvulaFareloId)
                    .HasConstraintName("FK_ValvulaFareloDiagramaCenario");

                entity.HasOne(d => d.ValvulaRemoido)
                    .WithMany(p => p.DiagramaCenarioValvulaRemoido)
                    .HasForeignKey(d => d.ValvulaRemoidoId)
                    .HasConstraintName("FK_ValvulaRemoidoDiagramaCenario");
            });

            modelBuilder.Entity<DivisorCenario>(entity =>
            {
                entity.HasKey(e => new { e.NoId, e.CenarioId });

                entity.HasIndex(e => e.TipoDivisorId)
                    .HasName("IX_FK_TipoDivisorDivisorCenario");

                entity.HasOne(d => d.Cenario)
                    .WithMany(p => p.DivisorCenario)
                    .HasForeignKey(d => d.CenarioId)
                    .HasConstraintName("FK_CenarioDivisorCenario");

                entity.HasOne(d => d.No)
                    .WithMany(p => p.DivisorCenario)
                    .HasForeignKey(d => d.NoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_NoDivisorCenario");

                entity.HasOne(d => d.TipoDivisor)
                    .WithMany(p => p.DivisorCenario)
                    .HasForeignKey(d => d.TipoDivisorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoDivisorDivisorCenario");
            });

            modelBuilder.Entity<ElementoTipoProduto>(entity =>
            {
                entity.HasKey(e => new { e.TipoEntidadeId, e.TipoProdutoId });

                entity.HasOne(d => d.TipoEntidade)
                    .WithMany(p => p.ElementoTipoProduto)
                    .HasForeignKey(d => d.TipoEntidadeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ElementoTipoProdutoTipoEntidade");

                entity.HasOne(d => d.TipoProduto)
                    .WithMany(p => p.ElementoTipoProduto)
                    .HasForeignKey(d => d.TipoProdutoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ElementoTipoProdutoTipoProduto");
            });

            modelBuilder.Entity<EntidadeSimbolo>(entity =>
            {
                entity.HasKey(e => new { e.Dimensao, e.SimboloId, e.TipoEntidadeId });

                entity.HasIndex(e => e.SimboloId)
                    .HasName("IX_FK_SimboloEntidadeSimbolo");

                entity.HasIndex(e => e.TipoEntidadeId)
                    .HasName("IX_FK_TipoEntidadeEntidadeSimbolo");

                entity.HasOne(d => d.Simbolo)
                    .WithMany(p => p.EntidadeSimbolo)
                    .HasForeignKey(d => d.SimboloId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_SimboloEntidadeSimbolo");

                entity.HasOne(d => d.TipoEntidade)
                    .WithMany(p => p.EntidadeSimbolo)
                    .HasForeignKey(d => d.TipoEntidadeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoEntidadeEntidadeSimbolo");
            });

            modelBuilder.Entity<Entrada>(entity =>
            {
                entity.HasIndex(e => e.TipoValorId)
                    .HasName("IX_FK_TipoValorEntrada");

                entity.HasIndex(e => new { e.CenarioId, e.SimboloId, e.EntidadeCodigo1, e.EntidadeCodigo2, e.EntidadeCodigo3, e.EntidadeCodigo4, e.EntidadeCodigo5, e.EntidadeCodigo6 })
                    .HasName("IX_Entrada")
                    .IsUnique();

                entity.HasIndex(e => new { e.Id, e.TipoValorId, e.Grandeza, e.EntidadeCodigo1, e.EntidadeCodigo2, e.EntidadeCodigo3, e.EntidadeCodigo4, e.EntidadeCodigo5, e.EntidadeCodigo6, e.CenarioId, e.SimboloId })
                    .HasName("IX_EntradaCenarioSimbolo");

                entity.Property(e => e.EntidadeCodigo1)
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.EntidadeCodigo2)
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.EntidadeCodigo3)
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.EntidadeCodigo4)
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.EntidadeCodigo5)
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.EntidadeCodigo6)
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.EntidadesCodigos).HasColumnType("xml");

                entity.Property(e => e.Grandeza).HasColumnType("decimal(38, 13)");

                entity.HasOne(d => d.Cenario)
                    .WithMany(p => p.Entrada)
                    .HasForeignKey(d => d.CenarioId)
                    .HasConstraintName("FK_EntradaCenario");

                entity.HasOne(d => d.Simbolo)
                    .WithMany(p => p.Entrada)
                    .HasForeignKey(d => d.SimboloId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_SimboloEntrada");

                entity.HasOne(d => d.TipoValor)
                    .WithMany(p => p.Entrada)
                    .HasForeignKey(d => d.TipoValorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoValorEntrada");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasIndex(e => e.Sigla)
                    .HasName("IX_FK_UnidadeFederacaoEstado");

                entity.HasIndex(e => e.TipoEntidadeId)
                    .HasName("IX_FK_TipoEntidadeEstado");

                entity.HasIndex(e => e.TopologiaId)
                    .HasName("IX_FK_TopologiaEstado");

                entity.HasIndex(e => new { e.TopologiaId, e.Sigla })
                    .HasName("IX_Estado_TopologiaIdSigla")
                    .IsUnique();

                entity.Property(e => e.Descricao)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Sigla)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.SiglaNavigation)
                    .WithMany(p => p.Estado)
                    .HasForeignKey(d => d.Sigla)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_UnidadeFederacaoEstado");

                entity.HasOne(d => d.TipoEntidade)
                    .WithMany(p => p.Estado)
                    .HasForeignKey(d => d.TipoEntidadeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoEntidadeEstado");

                entity.HasOne(d => d.Topologia)
                    .WithMany(p => p.Estado)
                    .HasForeignKey(d => d.TopologiaId)
                    .HasConstraintName("FK_TopologiaEstado");
            });

            modelBuilder.Entity<FaixaCustoFixo>(entity =>
            {
                entity.HasIndex(e => new { e.TopologiaId, e.Codigo })
                    .HasName("IX_FaixaCustoFixo")
                    .IsUnique();

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipoEntidade)
                    .WithMany(p => p.FaixaCustoFixo)
                    .HasForeignKey(d => d.TipoEntidadeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoEntidadeFaixaCustoFixo");

                entity.HasOne(d => d.Topologia)
                    .WithMany(p => p.FaixaCustoFixo)
                    .HasForeignKey(d => d.TopologiaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_FaixaCustoFixo_Cenario");
            });

            modelBuilder.Entity<FaixaDesconto>(entity =>
            {
                entity.HasIndex(e => e.DescontoId)
                    .HasName("IX_FK_DescontoFaixaDesconto");

                entity.HasIndex(e => e.TipoEntidadeId)
                    .HasName("IX_FK_TipoEntidadeFaixaDesconto");

                entity.HasIndex(e => e.TopologiaId)
                    .HasName("IX_FK_TopologiaFaixaDesconto");

                entity.HasIndex(e => new { e.TopologiaId, e.Codigo })
                    .HasName("IX_FaixaDesconto_TopologiaIdCodigo")
                    .IsUnique();

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.Desconto)
                    .WithMany(p => p.FaixaDesconto)
                    .HasForeignKey(d => d.DescontoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_DescontoFaixaDesconto");

                entity.HasOne(d => d.TipoEntidade)
                    .WithMany(p => p.FaixaDesconto)
                    .HasForeignKey(d => d.TipoEntidadeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoEntidadeFaixaDesconto");

                entity.HasOne(d => d.Topologia)
                    .WithMany(p => p.FaixaDesconto)
                    .HasForeignKey(d => d.TopologiaId)
                    .HasConstraintName("FK_TopologiaFaixaDesconto");
            });

            modelBuilder.Entity<Familia>(entity =>
            {
                entity.HasIndex(e => e.TipoEntidadeId)
                    .HasName("IX_FK_TipoEntidadeFamilia");

                entity.HasIndex(e => e.TipoProdutoId)
                    .HasName("IX_FK_TipoProdutoFamilia");

                entity.HasIndex(e => e.TopologiaId)
                    .HasName("IX_FK_TopologiaFamilia");

                entity.HasIndex(e => new { e.TopologiaId, e.Codigo })
                    .HasName("IX_Familia_TopologiaIdCodigo")
                    .IsUnique();

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipoEntidade)
                    .WithMany(p => p.Familia)
                    .HasForeignKey(d => d.TipoEntidadeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoEntidadeFamilia");

                entity.HasOne(d => d.TipoProduto)
                    .WithMany(p => p.Familia)
                    .HasForeignKey(d => d.TipoProdutoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoProdutoFamilia");

                entity.HasOne(d => d.Topologia)
                    .WithMany(p => p.Familia)
                    .HasForeignKey(d => d.TopologiaId)
                    .HasConstraintName("FK_TopologiaFamilia");
            });

            modelBuilder.Entity<FamiliaContrato>(entity =>
            {
                entity.HasKey(e => new { e.FamiliaId, e.ContratoId });

                entity.HasOne(d => d.Contrato)
                    .WithMany(p => p.FamiliaContrato)
                    .HasForeignKey(d => d.ContratoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ContratoFamiliaContrato");

                entity.HasOne(d => d.Familia)
                    .WithMany(p => p.FamiliaContrato)
                    .HasForeignKey(d => d.FamiliaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_FamiliaFamiliaContrato");
            });

            modelBuilder.Entity<FluxogramaDrawing>(entity =>
            {
                entity.HasIndex(e => e.TopologiaId)
                    .HasName("IX_FK_TopologiaFluxogramaDrawing");

                entity.HasIndex(e => new { e.TopologiaId, e.Nome })
                    .HasName("IX_FluxogramaDrawing_TopologiaIdNome")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Topologia)
                    .WithMany(p => p.FluxogramaDrawing)
                    .HasForeignKey(d => d.TopologiaId)
                    .HasConstraintName("FK_TopologiaFluxogramaDrawing");
            });

            modelBuilder.Entity<FornecimentoCenario>(entity =>
            {
                entity.HasKey(e => new { e.NoId, e.CenarioId });

                entity.HasIndex(e => e.CenarioId)
                    .HasName("IX_FK_CenarioFornecimentoCenario");

                entity.HasIndex(e => e.NoId)
                    .HasName("IX_FK_NoFornecimentoCenario");

                entity.HasIndex(e => new { e.CenarioId, e.NoId })
                    .HasName("IX_FornecimentoCenario_CenarioIdNoId")
                    .IsUnique();

                entity.HasOne(d => d.Cenario)
                    .WithMany(p => p.FornecimentoCenario)
                    .HasForeignKey(d => d.CenarioId)
                    .HasConstraintName("FK_CenarioFornecimentoCenario");

                entity.HasOne(d => d.No)
                    .WithMany(p => p.FornecimentoCenario)
                    .HasForeignKey(d => d.NoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_NoFornecimentoCenario");
            });

            modelBuilder.Entity<FuncaoObjetivo>(entity =>
            {
                entity.HasIndex(e => e.CadeiaId)
                    .HasName("IX_FK_CadeiaFuncaoObjetivo");

                entity.HasIndex(e => new { e.CadeiaId, e.Nome })
                    .HasName("IX_FuncaoObjetivo_CadeiaIdNome")
                    .IsUnique();

                entity.Property(e => e.Descricao)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cadeia)
                    .WithMany(p => p.FuncaoObjetivo)
                    .HasForeignKey(d => d.CadeiaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CadeiaFuncaoObjetivo");
            });

            modelBuilder.Entity<LabelPadraoTopologia>(entity =>
            {
                entity.HasIndex(e => e.LabelGuiid)
                    .HasName("IX_FK_LabelGUILabelPadraoTopologia");

                entity.HasIndex(e => e.TipoEntidadeId)
                    .HasName("IX_FK_TipoEntidadeLabelPadraoTopologia");

                entity.HasIndex(e => e.TopologiaId)
                    .HasName("IX_FK_TopologiaLabelPadraoTopologia");

                entity.Property(e => e.LabelGuiid).HasColumnName("LabelGUIId");

                entity.HasOne(d => d.TipoEntidade)
                    .WithMany(p => p.LabelPadraoTopologia)
                    .HasForeignKey(d => d.TipoEntidadeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoEntidadeLabelPadraoTopologia");

                entity.HasOne(d => d.Topologia)
                    .WithMany(p => p.LabelPadraoTopologia)
                    .HasForeignKey(d => d.TopologiaId)
                    .HasConstraintName("FK_TopologiaLabelPadraoTopologia");
            });

            modelBuilder.Entity<Limite>(entity =>
            {
                entity.HasIndex(e => e.CenarioId)
                    .HasName("IX_FK_CenarioLimite");

                entity.HasIndex(e => e.DadoCenarioId)
                    .HasName("IX_FK_DadoCenarioLimite");

                entity.HasIndex(e => e.TipoEntidadeId)
                    .HasName("IX_FK_TipoEntidadeLimite");

                entity.HasIndex(e => e.TipoLimiteId)
                    .HasName("IX_FK_TipoLimiteLimite");

                entity.HasOne(d => d.Cenario)
                    .WithMany(p => p.Limite)
                    .HasForeignKey(d => d.CenarioId)
                    .HasConstraintName("FK_CenarioLimite");

                entity.HasOne(d => d.TipoEntidade)
                    .WithMany(p => p.Limite)
                    .HasForeignKey(d => d.TipoEntidadeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoEntidadeLimite");

                entity.HasOne(d => d.TipoLimite)
                    .WithMany(p => p.Limite)
                    .HasForeignKey(d => d.TipoLimiteId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoLimiteLimite");
            });

            modelBuilder.Entity<MedidaCadeia>(entity =>
            {
                entity.HasKey(e => new { e.CadeiaId, e.UnidadeMedidaId });

                entity.HasIndex(e => e.CadeiaId)
                    .HasName("IX_FK_CadeiaMedidaCadeia");

                entity.HasIndex(e => e.UnidadeMedidaId)
                    .HasName("IX_FK_UnidadeMedidaMedidaCadeia");

                entity.HasOne(d => d.Cadeia)
                    .WithMany(p => p.MedidaCadeia)
                    .HasForeignKey(d => d.CadeiaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CadeiaMedidaCadeia");

                entity.HasOne(d => d.UnidadeMedida)
                    .WithMany(p => p.MedidaCadeia)
                    .HasForeignKey(d => d.UnidadeMedidaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_UnidadeMedidaMedidaCadeia");
            });

            modelBuilder.Entity<MedidaProjeto>(entity =>
            {
                entity.HasKey(e => new { e.ProjetoId, e.UnidadeMedidaId });

                entity.HasIndex(e => e.ProjetoId)
                    .HasName("IX_FK_ProjetoMedidaProjeto");

                entity.HasIndex(e => e.UnidadeMedidaId)
                    .HasName("IX_FK_TipoUnidadeMedidaProjeto");

                entity.HasOne(d => d.Projeto)
                    .WithMany(p => p.MedidaProjeto)
                    .HasForeignKey(d => d.ProjetoId)
                    .HasConstraintName("FK_ProjetoMedidaProjeto");

                entity.HasOne(d => d.UnidadeMedida)
                    .WithMany(p => p.MedidaProjeto)
                    .HasForeignKey(d => d.UnidadeMedidaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_UnidadeMedidaMedidaProjeto");
            });

            modelBuilder.Entity<MercadoCenario>(entity =>
            {
                entity.HasKey(e => new { e.NoId, e.CenarioId });

                entity.HasIndex(e => e.NoId)
                    .HasName("IX_FK_NoMercadoCenario");

                entity.HasIndex(e => e.TipoDemandaId)
                    .HasName("IX_FK_TipoDemandaMercadoCenario");

                entity.HasOne(d => d.Cenario)
                    .WithMany(p => p.MercadoCenario)
                    .HasForeignKey(d => d.CenarioId)
                    .HasConstraintName("FK_CenarioMercadoCenario");

                entity.HasOne(d => d.No)
                    .WithMany(p => p.MercadoCenario)
                    .HasForeignKey(d => d.NoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_NoMercadoCenario");

                entity.HasOne(d => d.PrecoBase)
                    .WithMany(p => p.MercadoCenario)
                    .HasForeignKey(d => d.PrecoBaseId)
                    .HasConstraintName("FK_PrecoBaseMercadoCenario");

                entity.HasOne(d => d.TipoDemanda)
                    .WithMany(p => p.MercadoCenario)
                    .HasForeignKey(d => d.TipoDemandaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoDemandaMercadoCenario");
            });

            modelBuilder.Entity<MercadoContrato>(entity =>
            {
                entity.HasKey(e => new { e.MercadoId, e.ContratoId });

                entity.HasOne(d => d.Contrato)
                    .WithMany(p => p.MercadoContrato)
                    .HasForeignKey(d => d.ContratoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MercadoContratoContrato");

                entity.HasOne(d => d.Mercado)
                    .WithMany(p => p.MercadoContrato)
                    .HasForeignKey(d => d.MercadoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MercadoContratoNo");
            });

            modelBuilder.Entity<Modal>(entity =>
            {
                entity.HasIndex(e => e.Nome)
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<No>(entity =>
            {
                entity.HasIndex(e => e.ConjuntoId)
                    .HasName("IX_FK_ConjuntoNo");

                entity.HasIndex(e => e.TipoEntidadeId)
                    .HasName("IX_FK_TipoEntidadeNo");

                entity.HasIndex(e => e.TopologiaId)
                    .HasName("IX_FK_TopologiaNo");

                entity.HasIndex(e => new { e.TopologiaId, e.Codigo })
                    .HasName("IX_No_TopologiaIdCodigo")
                    .IsUnique();

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Localizacao)
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.Nota)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Conjunto)
                    .WithMany(p => p.No)
                    .HasForeignKey(d => d.ConjuntoId)
                    .HasConstraintName("FK_ConjuntoNo");

                entity.HasOne(d => d.TipoEntidade)
                    .WithMany(p => p.No)
                    .HasForeignKey(d => d.TipoEntidadeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoEntidadeNo");

                entity.HasOne(d => d.Topologia)
                    .WithMany(p => p.No)
                    .HasForeignKey(d => d.TopologiaId)
                    .HasConstraintName("FK_TopologiaNo");
            });

            modelBuilder.Entity<NoCenarioFaixaCustoFixo>(entity =>
            {
                entity.HasKey(e => new { e.NoId, e.FaixaId, e.CenarioId });

                entity.HasOne(d => d.Cenario)
                    .WithMany(p => p.NoCenarioFaixaCustoFixo)
                    .HasForeignKey(d => d.CenarioId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_NoCennarioFaixaCustoFixo_Cenario");

                entity.HasOne(d => d.Faixa)
                    .WithMany(p => p.NoCenarioFaixaCustoFixo)
                    .HasForeignKey(d => d.FaixaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_NoCenarioFaixaCustoFixo_FaixaCustoFixo");

                entity.HasOne(d => d.No)
                    .WithMany(p => p.NoCenarioFaixaCustoFixo)
                    .HasForeignKey(d => d.NoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_NoCenarioFaixaCustoFixo_No");
            });

            modelBuilder.Entity<NoCenarioLimite>(entity =>
            {
                entity.HasKey(e => new { e.NoId, e.CenarioId });

                entity.Property(e => e.LimiteMaximoEntradaTotal)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LimiteMaximoSaidaTotal)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LimiteMinimoEntradaTotal)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LimiteMinimoSaidaTotal)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Cenario)
                    .WithMany(p => p.NoCenarioLimite)
                    .HasForeignKey(d => d.CenarioId)
                    .HasConstraintName("FK_NoCenarioLimiteCenario");

                entity.HasOne(d => d.No)
                    .WithMany(p => p.NoCenarioLimite)
                    .HasForeignKey(d => d.NoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_NoCenarioLimiteNo");
            });

            modelBuilder.Entity<NoCenarioSimbolo>(entity =>
            {
                entity.HasKey(e => new { e.NoId, e.CenarioId, e.SimboloId });

                entity.Property(e => e.Detalhado).HasDefaultValueSql("((1))");

                entity.Property(e => e.TipoEntrada).HasDefaultValueSql("((0))");

                entity.Property(e => e.ValorExato).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Cenario)
                    .WithMany(p => p.NoCenarioSimbolo)
                    .HasForeignKey(d => d.CenarioId)
                    .HasConstraintName("FK_NoCenarioSimboloCenario");

                entity.HasOne(d => d.No)
                    .WithMany(p => p.NoCenarioSimbolo)
                    .HasForeignKey(d => d.NoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_NoCenarioSimboloNo");

                entity.HasOne(d => d.Simbolo)
                    .WithMany(p => p.NoCenarioSimbolo)
                    .HasForeignKey(d => d.SimboloId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_NoCenarioSimboloSimbolo");
            });

            modelBuilder.Entity<NoDrawing>(entity =>
            {
                entity.HasKey(e => new { e.NoId, e.FluxogramaId });

                entity.HasIndex(e => new { e.NoId, e.FluxogramaId, e.Conector })
                    .HasName("IX_NoDrawing_NoIdFluxogramaIdConector")
                    .IsUnique();

                entity.HasOne(d => d.Fluxograma)
                    .WithMany(p => p.NoDrawing)
                    .HasForeignKey(d => d.FluxogramaId)
                    .HasConstraintName("FK_FluxogramaNoDrawing");

                entity.HasOne(d => d.No)
                    .WithMany(p => p.NoDrawing)
                    .HasForeignKey(d => d.NoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_NoNoDrawing");
            });

            modelBuilder.Entity<NoFamilia>(entity =>
            {
                entity.HasKey(e => new { e.NoId, e.FamiliaId });

                entity.HasOne(d => d.Familia)
                    .WithMany(p => p.NoFamilia)
                    .HasForeignKey(d => d.FamiliaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_NoFamiliaFamilia");

                entity.HasOne(d => d.No)
                    .WithMany(p => p.NoFamilia)
                    .HasForeignKey(d => d.NoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_NofamiliaNo");
            });

            modelBuilder.Entity<NoProduto>(entity =>
            {
                entity.HasKey(e => new { e.NoId, e.ProdutoId });

                entity.HasOne(d => d.No)
                    .WithMany(p => p.NoProduto)
                    .HasForeignKey(d => d.NoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_NoProdutoNo");

                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.NoProduto)
                    .HasForeignKey(d => d.ProdutoId)
                    .HasConstraintName("FK_NoProdutoProduto");
            });

            modelBuilder.Entity<Pais>(entity =>
            {
                entity.HasIndex(e => e.TipoEntidadeId)
                    .HasName("IX_FK_TipoEntidadePais");

                entity.HasIndex(e => e.TopologiaId)
                    .HasName("IX_FK_TopologiaPais");

                entity.HasIndex(e => new { e.TopologiaId, e.Codigo })
                    .HasName("IX_Pais_TopologiaIdCodigo")
                    .IsUnique();

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipoEntidade)
                    .WithMany(p => p.Pais)
                    .HasForeignKey(d => d.TipoEntidadeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoEntidadePais");

                entity.HasOne(d => d.Topologia)
                    .WithMany(p => p.Pais)
                    .HasForeignKey(d => d.TopologiaId)
                    .HasConstraintName("FK_TopologiaPais");
            });

            modelBuilder.Entity<Periodo>(entity =>
            {
                entity.HasIndex(e => e.TipoEntidadeId)
                    .HasName("IX_FK_TipoEntidadePeriodo");

                entity.HasIndex(e => e.TopologiaId)
                    .HasName("IX_FK_TopologiaPeriodo");

                entity.HasIndex(e => new { e.TopologiaId, e.Codigo })
                    .HasName("IX_Periodo_TopologiaIdCodigo")
                    .IsUnique();

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipoEntidade)
                    .WithMany(p => p.Periodo)
                    .HasForeignKey(d => d.TipoEntidadeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoEntidadePeriodo");

                entity.HasOne(d => d.Topologia)
                    .WithMany(p => p.Periodo)
                    .HasForeignKey(d => d.TopologiaId)
                    .HasConstraintName("FK_TopologiaPeriodo");
            });

            modelBuilder.Entity<PeriodoAgregado>(entity =>
            {
                entity.HasIndex(e => e.ConjuntoId)
                    .HasName("IX_FK_ConjuntoPeriodoAgregado");

                entity.HasIndex(e => e.TipoEntidadeId)
                    .HasName("IX_FK_TipoEntidadePeriodoAgregado");

                entity.HasIndex(e => e.TopologiaId)
                    .HasName("IX_FK_TopologiaPeriodoAgregado");

                entity.HasIndex(e => new { e.TopologiaId, e.Codigo })
                    .HasName("IX_PeriodoAgregado_TopologiaIdCodigo")
                    .IsUnique();

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.Conjunto)
                    .WithMany(p => p.PeriodoAgregado)
                    .HasForeignKey(d => d.ConjuntoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Conjunto");

                entity.HasOne(d => d.TipoEntidade)
                    .WithMany(p => p.PeriodoAgregado)
                    .HasForeignKey(d => d.TipoEntidadeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoEntidadePeriodoAgregado");

                entity.HasOne(d => d.Topologia)
                    .WithMany(p => p.PeriodoAgregado)
                    .HasForeignKey(d => d.TopologiaId)
                    .HasConstraintName("FK_TopologiaPeriodoAgregado");
            });

            modelBuilder.Entity<PeriodoAgregadoItem>(entity =>
            {
                entity.HasKey(e => new { e.PeriodoAgregadoId, e.PeriodoId });

                entity.HasIndex(e => e.PeriodoAgregadoId)
                    .HasName("IX_FK_PeriodoAgregadoPeriodoAgregadoItem");

                entity.HasIndex(e => e.PeriodoId)
                    .HasName("IX_FK_PeriodoPeriodoAgregadoItem");

                entity.HasOne(d => d.PeriodoAgregado)
                    .WithMany(p => p.PeriodoAgregadoItem)
                    .HasForeignKey(d => d.PeriodoAgregadoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PeriodoAgregadoPeriodoAgregadoItem");

                entity.HasOne(d => d.Periodo)
                    .WithMany(p => p.PeriodoAgregadoItem)
                    .HasForeignKey(d => d.PeriodoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PeriodoPeriodoAgregadoItem");
            });

            modelBuilder.Entity<PeriodoCenario>(entity =>
            {
                entity.HasKey(e => new { e.CenarioId, e.PeriodoId });

                entity.HasOne(d => d.Cenario)
                    .WithMany(p => p.PeriodoCenario)
                    .HasForeignKey(d => d.CenarioId)
                    .HasConstraintName("FK_PeriodoCenario_Cenario");

                entity.HasOne(d => d.Periodo)
                    .WithMany(p => p.PeriodoCenario)
                    .HasForeignKey(d => d.PeriodoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PeriodoCenario_Periodo");
            });

            modelBuilder.Entity<PortaDrawing>(entity =>
            {
                entity.HasIndex(e => new { e.Id, e.Index })
                    .HasName("IX_PortaDrawing_Index")
                    .IsUnique();

                entity.HasIndex(e => new { e.NoId, e.FluxogramaId })
                    .HasName("IX_FK_NoDrawingPortaDrawing");

                entity.HasOne(d => d.NoDrawing)
                    .WithMany(p => p.PortaDrawing)
                    .HasForeignKey(d => new { d.NoId, d.FluxogramaId })
                    .HasConstraintName("FK_NoDrawingPortaDrawing");
            });

            modelBuilder.Entity<PortoCenario>(entity =>
            {
                entity.HasKey(e => new { e.NoId, e.CenarioId });

                entity.HasIndex(e => e.TipoArmazenamentoId)
                    .HasName("IX_FK_TipoArmazenamentoPortoCenario");

                entity.HasOne(d => d.Cenario)
                    .WithMany(p => p.PortoCenario)
                    .HasForeignKey(d => d.CenarioId)
                    .HasConstraintName("FK_CenarioPortoCenario");

                entity.HasOne(d => d.No)
                    .WithMany(p => p.PortoCenario)
                    .HasForeignKey(d => d.NoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_NoPortoCenario");

                entity.HasOne(d => d.TipoArmazenamento)
                    .WithMany(p => p.PortoCenario)
                    .HasForeignKey(d => d.TipoArmazenamentoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoArmazenamentoPortoCenario");
            });

            modelBuilder.Entity<PrecoBase>(entity =>
            {
                entity.HasIndex(e => e.TipoEntidadeId)
                    .HasName("IX_FK_TipoEntidadePrecoBase");

                entity.HasIndex(e => e.TopologiaId)
                    .HasName("IX_FK_TopologiaPrecoBase");

                entity.HasIndex(e => new { e.TopologiaId, e.Codigo })
                    .HasName("IX_PrecoBase_TopologiaIdCodigo")
                    .IsUnique();

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipoEntidade)
                    .WithMany(p => p.PrecoBase)
                    .HasForeignKey(d => d.TipoEntidadeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoEntidadePrecoBase");

                entity.HasOne(d => d.Topologia)
                    .WithMany(p => p.PrecoBase)
                    .HasForeignKey(d => d.TopologiaId)
                    .HasConstraintName("FK_TopologiaPrecoBase");
            });

            modelBuilder.Entity<ProcessamentoCenario>(entity =>
            {
                entity.HasKey(e => new { e.NoId, e.CenarioId });

                entity.HasIndex(e => e.CenarioId)
                    .HasName("IX_FK_CenarioProcessamentoCenario");

                entity.HasIndex(e => e.NoId)
                    .HasName("IX_FK_NoProcessamentoCenario");

                entity.HasOne(d => d.Cenario)
                    .WithMany(p => p.ProcessamentoCenario)
                    .HasForeignKey(d => d.CenarioId)
                    .HasConstraintName("FK_CenarioProcessamentoCenario");

                entity.HasOne(d => d.No)
                    .WithMany(p => p.ProcessamentoCenario)
                    .HasForeignKey(d => d.NoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_NoProcessamentoCenario");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasIndex(e => e.TipoEntidadeId)
                    .HasName("IX_FK_TipoEntidadeProduto");

                entity.HasIndex(e => e.TopologiaId)
                    .HasName("IX_FK_TopologiaProduto");

                entity.HasIndex(e => e.UnidadeMedidaId)
                    .HasName("IX_FK_UnidadeMedidaProduto");

                entity.HasIndex(e => new { e.TopologiaId, e.Codigo })
                    .HasName("IX_Produto_TopologiaIdCodigo")
                    .IsUnique();

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipoEntidade)
                    .WithMany(p => p.Produto)
                    .HasForeignKey(d => d.TipoEntidadeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoEntidadeProduto");

                entity.HasOne(d => d.Topologia)
                    .WithMany(p => p.Produto)
                    .HasForeignKey(d => d.TopologiaId)
                    .HasConstraintName("FK_TopologiaProduto");

                entity.HasOne(d => d.UnidadeMedida)
                    .WithMany(p => p.Produto)
                    .HasForeignKey(d => d.UnidadeMedidaId)
                    .HasConstraintName("FK_UnidadeMedidaProduto");
            });

            modelBuilder.Entity<ProdutoCenarioSimbolo>(entity =>
            {
                entity.HasKey(e => new { e.ProdutoId, e.CenarioId, e.SimboloId });

                entity.HasOne(d => d.Cenario)
                    .WithMany(p => p.ProdutoCenarioSimbolo)
                    .HasForeignKey(d => d.CenarioId)
                    .HasConstraintName("FK_ProdutoCenarioSimboloCenario");

                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.ProdutoCenarioSimbolo)
                    .HasForeignKey(d => d.ProdutoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ProdutoCenarioSimboloNo");

                entity.HasOne(d => d.Simbolo)
                    .WithMany(p => p.ProdutoCenarioSimbolo)
                    .HasForeignKey(d => d.SimboloId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ProdutoCenarioSimboloSimbolo");
            });

            modelBuilder.Entity<ProdutoContrato>(entity =>
            {
                entity.HasKey(e => new { e.ProdutoId, e.ContratoId });

                entity.HasOne(d => d.Contrato)
                    .WithMany(p => p.ProdutoContrato)
                    .HasForeignKey(d => d.ContratoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ContratoProdutoContrato");

                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.ProdutoContrato)
                    .HasForeignKey(d => d.ProdutoId)
                    .HasConstraintName("FK_ProdutoProdutoContrato");
            });

            modelBuilder.Entity<ProdutoFamilia>(entity =>
            {
                entity.HasKey(e => new { e.ProdutoId, e.FamiliaId });

                entity.HasOne(d => d.Familia)
                    .WithMany(p => p.ProdutoFamilia)
                    .HasForeignKey(d => d.FamiliaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ProdutoFamiliaFamilia");

                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.ProdutoFamilia)
                    .HasForeignKey(d => d.ProdutoId)
                    .HasConstraintName("FK_ProdutFamiliaProduto");
            });

            modelBuilder.Entity<Projeto>(entity =>
            {
                entity.HasIndex(e => e.CadeiaId)
                    .HasName("IX_FK_CadeiaProjeto");

                entity.HasIndex(e => new { e.CadeiaId, e.Nome })
                    .HasName("IX_Projeto_CadeiaIdNome")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nota)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cadeia)
                    .WithMany(p => p.Projeto)
                    .HasForeignKey(d => d.CadeiaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CadeiaProjeto");
            });

            modelBuilder.Entity<Propriedade>(entity =>
            {
                entity.HasIndex(e => e.CadeiaId)
                    .HasName("IX_FK_CadeiaPropriedade");

                entity.HasIndex(e => e.Nome)
                    .IsUnique();

                entity.HasIndex(e => e.TipoPropriedadeId)
                    .HasName("IX_FK_TipoPropriedadePropriedade");

                entity.HasIndex(e => e.UnidadeMedidaId)
                    .HasName("IX_FK_UnidadeMedidaPropriedade");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cadeia)
                    .WithMany(p => p.Propriedade)
                    .HasForeignKey(d => d.CadeiaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CadeiaPropriedade");

                entity.HasOne(d => d.TipoPropriedade)
                    .WithMany(p => p.Propriedade)
                    .HasForeignKey(d => d.TipoPropriedadeId)
                    .HasConstraintName("FK_TipoPropriedadePropriedade");

                entity.HasOne(d => d.UnidadeMedida)
                    .WithMany(p => p.Propriedade)
                    .HasForeignKey(d => d.UnidadeMedidaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_UnidadeMedidaPropriedade");
            });

            modelBuilder.Entity<PropriedadeAgrupamento>(entity =>
            {
                entity.HasKey(e => new { e.PaiId, e.DependenteId });

                entity.HasOne(d => d.Dependente)
                    .WithMany(p => p.PropriedadeAgrupamentoDependente)
                    .HasForeignKey(d => d.DependenteId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PropriedadeAgrupamentoPropriedadeDependente");

                entity.HasOne(d => d.Pai)
                    .WithMany(p => p.PropriedadeAgrupamentoPai)
                    .HasForeignKey(d => d.PaiId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PropriedadeAgrupamentoPropriedadePai");
            });

            modelBuilder.Entity<PropriedadeProduto>(entity =>
            {
                entity.HasKey(e => new { e.PropriedadeId, e.ProdutoId });

                entity.HasIndex(e => e.ProdutoId)
                    .HasName("IX_FK_ProdutoPropriedadeProduto");

                entity.HasIndex(e => e.PropriedadeId)
                    .HasName("IX_FK_PropriedadePropriedadeProduto");

                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.PropriedadeProduto)
                    .HasForeignKey(d => d.ProdutoId)
                    .HasConstraintName("FK_ProdutoPropriedadeProduto");

                entity.HasOne(d => d.Propriedade)
                    .WithMany(p => p.PropriedadeProduto)
                    .HasForeignKey(d => d.PropriedadeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PropriedadePropriedadeProduto");
            });

            modelBuilder.Entity<PropriedadeTopologia>(entity =>
            {
                entity.HasIndex(e => e.PropriedadeId)
                    .HasName("IX_FK_PropriedadePropriedadeTopologia");

                entity.HasIndex(e => e.TopologiaId)
                    .HasName("IX_FK_TopologiaPropriedadeTopologia");

                entity.HasIndex(e => new { e.PropriedadeId, e.TopologiaId })
                    .HasName("IX_PropriedadeTopologia_PropriedadeIdTopologiaId")
                    .IsUnique();

                entity.HasOne(d => d.Propriedade)
                    .WithMany(p => p.PropriedadeTopologia)
                    .HasForeignKey(d => d.PropriedadeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PropriedadePropriedadeTopologia");

                entity.HasOne(d => d.Topologia)
                    .WithMany(p => p.PropriedadeTopologia)
                    .HasForeignKey(d => d.TopologiaId)
                    .HasConstraintName("FK_TopologiaPropriedadeTopologia");
            });

            modelBuilder.Entity<Regiao>(entity =>
            {
                entity.HasIndex(e => e.ConjuntoId)
                    .HasName("IX_FK_ConjuntoRegiao");

                entity.HasIndex(e => e.TipoEntidadeId)
                    .HasName("IX_FK_TipoEntidadeRegiao");

                entity.HasIndex(e => e.TopologiaId)
                    .HasName("IX_FK_TopologiaRegiao");

                entity.HasIndex(e => new { e.TopologiaId, e.Codigo })
                    .HasName("IX_Regiao_TopologiaIdCodigo")
                    .IsUnique();

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.Conjunto)
                    .WithMany(p => p.Regiao)
                    .HasForeignKey(d => d.ConjuntoId)
                    .HasConstraintName("FK_ConjuntoRegiao");

                entity.HasOne(d => d.TipoEntidade)
                    .WithMany(p => p.Regiao)
                    .HasForeignKey(d => d.TipoEntidadeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoEntidadeRegiao");

                entity.HasOne(d => d.Topologia)
                    .WithMany(p => p.Regiao)
                    .HasForeignKey(d => d.TopologiaId)
                    .HasConstraintName("FK_TopologiaRegiao");
            });

            modelBuilder.Entity<Restricao>(entity =>
            {
                entity.HasIndex(e => e.TipoEntidadeId)
                    .HasName("IX_FK_TipoEntidadeRestricao");

                entity.HasIndex(e => e.TipoProdutoId)
                    .HasName("IX_FK_TipoProdutoRestricao");

                entity.HasIndex(e => e.TipoRestricaoId)
                    .HasName("IX_FK_TipoRestricaoRestricao");

                entity.HasIndex(e => e.TopologiaId)
                    .HasName("IX_FK_TopologiaRestricao");

                entity.HasIndex(e => new { e.TopologiaId, e.Codigo })
                    .HasName("IX_Restricao_TopologiaIdCodigo")
                    .IsUnique();

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipoEntidade)
                    .WithMany(p => p.Restricao)
                    .HasForeignKey(d => d.TipoEntidadeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoEntidadeRestricao");

                entity.HasOne(d => d.TipoProduto)
                    .WithMany(p => p.Restricao)
                    .HasForeignKey(d => d.TipoProdutoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoProdutoRestricao");

                entity.HasOne(d => d.TipoRestricao)
                    .WithMany(p => p.Restricao)
                    .HasForeignKey(d => d.TipoRestricaoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoRestricaoRestricao");

                entity.HasOne(d => d.Topologia)
                    .WithMany(p => p.Restricao)
                    .HasForeignKey(d => d.TopologiaId)
                    .HasConstraintName("FK_TopologiaRestricao");
            });

            modelBuilder.Entity<RestricaoCenario>(entity =>
            {
                entity.HasKey(e => new { e.RestricaoId, e.CenarioId });

                entity.HasIndex(e => e.PeriodoId)
                    .HasName("IX_FK_PeriodoRestricaoCenario");

                entity.HasOne(d => d.Cenario)
                    .WithMany(p => p.RestricaoCenario)
                    .HasForeignKey(d => d.CenarioId)
                    .HasConstraintName("FK_CenarioRestricaoCenario");

                entity.HasOne(d => d.Periodo)
                    .WithMany(p => p.RestricaoCenario)
                    .HasForeignKey(d => d.PeriodoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PeriodoRestricaoCenario");

                entity.HasOne(d => d.Restricao)
                    .WithMany(p => p.RestricaoCenario)
                    .HasForeignKey(d => d.RestricaoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_RestricaoRestricaoCenario");
            });

            modelBuilder.Entity<RestricaoCorrente>(entity =>
            {
                entity.HasKey(e => new { e.RestricaoId, e.CorrenteId });

                entity.HasOne(d => d.Corrente)
                    .WithMany(p => p.RestricaoCorrente)
                    .HasForeignKey(d => d.CorrenteId)
                    .HasConstraintName("FK_CorrenteRestricaoCorrente");

                entity.HasOne(d => d.Restricao)
                    .WithMany(p => p.RestricaoCorrente)
                    .HasForeignKey(d => d.RestricaoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_RestricaoRestricaoCorrente");
            });

            modelBuilder.Entity<RestricaoNo>(entity =>
            {
                entity.HasKey(e => new { e.RestricaoId, e.NoId });

                entity.HasOne(d => d.No)
                    .WithMany(p => p.RestricaoNo)
                    .HasForeignKey(d => d.NoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_NoRestricaoNo");

                entity.HasOne(d => d.Restricao)
                    .WithMany(p => p.RestricaoNo)
                    .HasForeignKey(d => d.RestricaoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_RestricaoRestricaoNo");
            });

            modelBuilder.Entity<Resultado>(entity =>
            {
                entity.HasIndex(e => e.CalculoId)
                    .HasName("IX_FK_CalculoResultado");

                entity.HasIndex(e => e.EntidadeCodigo1)
                    .HasName("IX_FK_Entidade1Resultado");

                entity.HasIndex(e => e.EntidadeCodigo2)
                    .HasName("IX_FK_Entidade2Resultado");

                entity.HasIndex(e => e.EntidadeCodigo3)
                    .HasName("IX_FK_Entidade3Resultado");

                entity.HasIndex(e => e.EntidadeCodigo4)
                    .HasName("IX_FK_Entidade4Resultado");

                entity.HasIndex(e => e.EntidadeCodigo5)
                    .HasName("IX_FK_Entidade5Resultado");

                entity.HasIndex(e => e.EntidadeCodigo6)
                    .HasName("IX_FK_Entidade6Resultado");

                entity.HasIndex(e => e.SimboloId)
                    .HasName("IX_FK_SimboloResultado");

                entity.HasIndex(e => e.TipoValorId)
                    .HasName("IX_FK_TipoValorResultado");

                entity.HasIndex(e => e.UnidadeMedidaDenominadorId)
                    .HasName("IX_FK_UnidadeMedidaDenominadorResultado");

                entity.HasIndex(e => e.UnidadeMedidaNumeradorId)
                    .HasName("IX_FK_UnidadeMedidaNumeradorResultado");

                entity.HasIndex(e => new { e.TipoValorId, e.Grandeza, e.Marginal, e.CalculoId, e.SimboloId, e.EntidadeCodigo1, e.UnidadeMedidaNumeradorId, e.UnidadeMedidaDenominadorId, e.EntidadeCodigo2, e.EntidadeCodigo3, e.EntidadeCodigo4, e.EntidadeCodigo5, e.EntidadeCodigo6 })
                    .HasName("IX_Resultado_1");

                entity.Property(e => e.EntidadeCodigo1)
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.EntidadeCodigo2)
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.EntidadeCodigo3)
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.EntidadeCodigo4)
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.EntidadeCodigo5)
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.EntidadeCodigo6)
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.Grandeza).HasColumnType("decimal(38, 13)");

                entity.HasOne(d => d.Calculo)
                    .WithMany(p => p.Resultado)
                    .HasForeignKey(d => d.CalculoId)
                    .HasConstraintName("FK_CalculoResultado");

                entity.HasOne(d => d.Simbolo)
                    .WithMany(p => p.Resultado)
                    .HasForeignKey(d => d.SimboloId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_SimboloResultado");

                entity.HasOne(d => d.TipoValor)
                    .WithMany(p => p.Resultado)
                    .HasForeignKey(d => d.TipoValorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoValorResultado");

                entity.HasOne(d => d.UnidadeMedidaDenominador)
                    .WithMany(p => p.ResultadoUnidadeMedidaDenominador)
                    .HasForeignKey(d => d.UnidadeMedidaDenominadorId)
                    .HasConstraintName("FK_UnidadeMedidaDenominadorResultado");

                entity.HasOne(d => d.UnidadeMedidaNumerador)
                    .WithMany(p => p.ResultadoUnidadeMedidaNumerador)
                    .HasForeignKey(d => d.UnidadeMedidaNumeradorId)
                    .HasConstraintName("FK_UnidadeMedidaNumeradorResultado");
            });

            modelBuilder.Entity<Silo>(entity =>
            {
                entity.HasIndex(e => e.ConjuntoId)
                    .HasName("IX_FK_ConjuntoSilo");

                entity.HasIndex(e => e.TipoEntidadeId)
                    .HasName("IX_FK_TipoEntidadeSilo");

                entity.HasIndex(e => e.TopologiaId)
                    .HasName("IX_FK_TopologiaSilo");

                entity.HasIndex(e => new { e.TopologiaId, e.Codigo })
                    .HasName("IX_Silo_TopologiaIdCodigo")
                    .IsUnique();

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.Conjunto)
                    .WithMany(p => p.Silo)
                    .HasForeignKey(d => d.ConjuntoId)
                    .HasConstraintName("FK_ConjuntoSilo");

                entity.HasOne(d => d.TipoEntidade)
                    .WithMany(p => p.Silo)
                    .HasForeignKey(d => d.TipoEntidadeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoEntidadeSilo");

                entity.HasOne(d => d.Topologia)
                    .WithMany(p => p.Silo)
                    .HasForeignKey(d => d.TopologiaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TopologiaSilo");
            });

            modelBuilder.Entity<Simbolo>(entity =>
            {
                entity.HasIndex(e => e.CadeiaId)
                    .HasName("IX_FK_CadeiaSimbolo");

                entity.HasIndex(e => e.TipoUnidadeDenominadorId)
                    .HasName("IX_FK_TipoUnidadeDenominadorSimbolo");

                entity.HasIndex(e => e.TipoUnidadeNumeradorId)
                    .HasName("IX_FK_TipoUnidadeNumeradorSimbolo");

                entity.HasIndex(e => new { e.CadeiaId, e.Codigo })
                    .HasName("IX_SimboloCodigo")
                    .IsUnique();

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Default).HasColumnType("decimal(38, 13)");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cadeia)
                    .WithMany(p => p.Simbolo)
                    .HasForeignKey(d => d.CadeiaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CadeiaSimbolo");

                entity.HasOne(d => d.TipoUnidadeDenominador)
                    .WithMany(p => p.SimboloTipoUnidadeDenominador)
                    .HasForeignKey(d => d.TipoUnidadeDenominadorId)
                    .HasConstraintName("FK_TipoUnidadeDenominadorSimbolo");

                entity.HasOne(d => d.TipoUnidadeNumerador)
                    .WithMany(p => p.SimboloTipoUnidadeNumerador)
                    .HasForeignKey(d => d.TipoUnidadeNumeradorId)
                    .HasConstraintName("FK_TipoUnidadeNumeradorSimbolo");
            });

            modelBuilder.Entity<SituacaoCalculo>(entity =>
            {
                entity.HasIndex(e => e.Nome)
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TemplateMedida>(entity =>
            {
                entity.HasKey(e => new { e.CadeiaId, e.TipoUnidadeId });

                entity.HasIndex(e => e.CadeiaId)
                    .HasName("IX_FK_CadeiaTemplateMedida");

                entity.HasIndex(e => e.TipoUnidadeId)
                    .HasName("IX_FK_TipoUnidadeTemplateMedida");

                entity.HasOne(d => d.Cadeia)
                    .WithMany(p => p.TemplateMedida)
                    .HasForeignKey(d => d.CadeiaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CadeiaTemplateMedida");

                entity.HasOne(d => d.TipoUnidade)
                    .WithMany(p => p.TemplateMedida)
                    .HasForeignKey(d => d.TipoUnidadeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoUnidadeTemplateMedida");
            });

            modelBuilder.Entity<TipoArmazenamento>(entity =>
            {
                entity.HasIndex(e => e.Nome)
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoDemanda>(entity =>
            {
                entity.HasIndex(e => e.Nome)
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoDivisor>(entity =>
            {
                entity.HasIndex(e => e.Nome)
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoEntidade>(entity =>
            {
                entity.HasIndex(e => e.Nome)
                    .IsUnique();

                entity.HasIndex(e => e.Prefixo)
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Prefixo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoLimite>(entity =>
            {
                entity.HasIndex(e => e.Nome)
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoLimiteCorrente>(entity =>
            {
                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoProduto>(entity =>
            {
                entity.HasIndex(e => e.Nome)
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.TipoProduto)
                    .HasForeignKey<TipoProduto>(d => d.Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoEntidadeTipoProduto");

                entity.HasOne(d => d.TipoUnidade)
                    .WithMany(p => p.TipoProduto)
                    .HasForeignKey(d => d.TipoUnidadeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoUnidadeTipoProduto");
            });

            modelBuilder.Entity<TipoPropriedade>(entity =>
            {
                entity.HasIndex(e => e.Nome)
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoRestricao>(entity =>
            {
                entity.HasIndex(e => e.Nome)
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUnidade>(entity =>
            {
                entity.HasIndex(e => e.Nome)
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoValor>(entity =>
            {
                entity.HasIndex(e => e.Nome)
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Topologia>(entity =>
            {
                entity.HasIndex(e => e.ProjetoId)
                    .HasName("IX_FK_ProjetoTopologia");

                entity.HasIndex(e => new { e.ProjetoId, e.Nome })
                    .HasName("IX_Topologia_ProjetoIdNome")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Projeto)
                    .WithMany(p => p.Topologia)
                    .HasForeignKey(d => d.ProjetoId)
                    .HasConstraintName("FK_ProjetoTopologia");
            });

            modelBuilder.Entity<UnidadeComposta>(entity =>
            {
                entity.HasIndex(e => e.DenominadorId)
                    .HasName("IX_FK_UnidadeMedidaDenominadorUnidadeComposta");

                entity.HasIndex(e => e.NumeradorId)
                    .HasName("IX_FK_UnidadeMedidaNumeradorUnidadeComposta");

                entity.HasOne(d => d.Denominador)
                    .WithMany(p => p.UnidadeCompostaDenominador)
                    .HasForeignKey(d => d.DenominadorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_UnidadeMedidaDenominadorUnidadeComposta");

                entity.HasOne(d => d.Numerador)
                    .WithMany(p => p.UnidadeCompostaNumerador)
                    .HasForeignKey(d => d.NumeradorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_UnidadeMedidaNumeradorUnidadeComposta");
            });

            modelBuilder.Entity<UnidadeFederacao>(entity =>
            {
                entity.HasKey(e => e.Sigla);

                entity.HasIndex(e => e.Nome)
                    .IsUnique();

                entity.Property(e => e.Sigla)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UnidadeMedida>(entity =>
            {
                entity.HasIndex(e => e.Nome)
                    .IsUnique();

                entity.HasIndex(e => e.TipoUnidadeId)
                    .HasName("IX_FK_TipoUnidadeUnidadeMedida");

                entity.Property(e => e.FatorConversao).HasColumnType("decimal(31, 24)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Representacao)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.HasOne(d => d.TipoUnidade)
                    .WithMany(p => p.UnidadeMedida)
                    .HasForeignKey(d => d.TipoUnidadeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoUnidadeUnidadeMedida");
            });

            modelBuilder.Entity<UnificadorCenario>(entity =>
            {
                entity.HasKey(e => new { e.NoId, e.CenarioId });

                entity.HasOne(d => d.Cenario)
                    .WithMany(p => p.UnificadorCenario)
                    .HasForeignKey(d => d.CenarioId)
                    .HasConstraintName("FK_CenarioUnificadorCenario");

                entity.HasOne(d => d.No)
                    .WithMany(p => p.UnificadorCenario)
                    .HasForeignKey(d => d.NoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_NoUnificadorCenario");
            });

            modelBuilder.Entity<Valvula>(entity =>
            {
                entity.HasIndex(e => e.ConjuntoId)
                    .HasName("IX_FK_ConjuntoValvula");

                entity.HasIndex(e => e.TipoEntidadeId)
                    .HasName("IX_FK_TipoEntidadeValvula");

                entity.HasIndex(e => e.TopologiaId)
                    .HasName("IX_FK_TopologiaValvula");

                entity.HasIndex(e => new { e.TopologiaId, e.Codigo })
                    .HasName("IX_Valvula_TopologiaIdCodigo")
                    .IsUnique();

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(63)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.Conjunto)
                    .WithMany(p => p.Valvula)
                    .HasForeignKey(d => d.ConjuntoId)
                    .HasConstraintName("FK_ConjuntoValvula");

                entity.HasOne(d => d.TipoEntidade)
                    .WithMany(p => p.Valvula)
                    .HasForeignKey(d => d.TipoEntidadeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TipoEntidadeValvula");

                entity.HasOne(d => d.Topologia)
                    .WithMany(p => p.Valvula)
                    .HasForeignKey(d => d.TopologiaId)
                    .HasConstraintName("FK_TopologiaValvula");
            });

        }
        #endregion
    }
}
