using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErlezQue.Infrastructure
{
    public class DbDesign
    {
        #region dropBill
        public static string dropBill = @"USE [master]

/****** Object:  Database [Bill]    Script Date: 2015-04-02 10:40:33 ******/
DROP DATABASE [Bill];

/****** Object:  Database [Bill]    Script Date: 2015-04-02 10:40:33 ******/
CREATE DATABASE [Bill]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Bill', FILENAME = N'C:\Users\mats.drevstad\Bill.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Bill_log', FILENAME = N'C:\Users\mats.drevstad\Bill_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
;

ALTER DATABASE [Bill] SET COMPATIBILITY_LEVEL = 110
;

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Bill].[dbo].[sp_fulltext_database] @action = 'enable'
end
;

ALTER DATABASE [Bill] SET ANSI_NULL_DEFAULT OFF 
;

ALTER DATABASE [Bill] SET ANSI_NULLS OFF 
;

ALTER DATABASE [Bill] SET ANSI_PADDING OFF 
;

ALTER DATABASE [Bill] SET ANSI_WARNINGS OFF 
;

ALTER DATABASE [Bill] SET ARITHABORT OFF 
;

ALTER DATABASE [Bill] SET AUTO_CLOSE OFF 
;

ALTER DATABASE [Bill] SET AUTO_SHRINK OFF 
;

ALTER DATABASE [Bill] SET AUTO_UPDATE_STATISTICS ON 
;

ALTER DATABASE [Bill] SET CURSOR_CLOSE_ON_COMMIT OFF 
;

ALTER DATABASE [Bill] SET CURSOR_DEFAULT  GLOBAL 
;

ALTER DATABASE [Bill] SET CONCAT_NULL_YIELDS_NULL OFF 
;

ALTER DATABASE [Bill] SET NUMERIC_ROUNDABORT OFF 
;

ALTER DATABASE [Bill] SET QUOTED_IDENTIFIER OFF 
;

ALTER DATABASE [Bill] SET RECURSIVE_TRIGGERS OFF 
;

ALTER DATABASE [Bill] SET  DISABLE_BROKER 
;

ALTER DATABASE [Bill] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
;

ALTER DATABASE [Bill] SET DATE_CORRELATION_OPTIMIZATION OFF 
;

ALTER DATABASE [Bill] SET TRUSTWORTHY OFF 
;

ALTER DATABASE [Bill] SET ALLOW_SNAPSHOT_ISOLATION OFF 
;

ALTER DATABASE [Bill] SET PARAMETERIZATION SIMPLE 
;

ALTER DATABASE [Bill] SET READ_COMMITTED_SNAPSHOT OFF 
;

ALTER DATABASE [Bill] SET HONOR_BROKER_PRIORITY OFF 
;

ALTER DATABASE [Bill] SET RECOVERY SIMPLE 
;

ALTER DATABASE [Bill] SET  MULTI_USER 
;

ALTER DATABASE [Bill] SET PAGE_VERIFY CHECKSUM  
;

ALTER DATABASE [Bill] SET DB_CHAINING OFF 
;

ALTER DATABASE [Bill] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
;

ALTER DATABASE [Bill] SET TARGET_RECOVERY_TIME = 0 SECONDS 
;

ALTER DATABASE [Bill] SET  READ_WRITE 
;
";
        #endregion

        #region createBill
        public static string createBill = @"
USE [Bill]
;
/****** Object:  Table [dbo].[Head]    Script Date: 03/12/2015 14:42:50 ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
SET ANSI_PADDING ON
;
CREATE TABLE [dbo].[Head](
	[PostId] [int] IDENTITY(1,1) NOT NULL,
	[IAID] [varchar](50) NULL,
	[Flow] [varchar](50) NULL,
	[InvoiceNo] [varchar](50) NULL,
	[OutputType] [varchar](50) NULL,
	[UpdateCode] [int] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[InvoiceType] [varchar](5) NULL,
	[InvoiceDate] [varchar](50) NULL,
	[RealDelDate] [varchar](50) NULL,
	[RealDelShip] [varchar](50) NULL,
	[HorizonStartDate] [varchar](50) NULL,
	[HorizonEndDate] [varchar](50) NULL,
	[PeriodFrom] [varchar](50) NULL,
	[PeriodTo] [varchar](50) NULL,
	[CreditReason] [varchar](50) NULL,
	[MaterialType] [varchar](50) NULL,
	[GUID] [varchar](50) NULL,
	[Timestamp] [varchar](50) NULL,
	[ErpVersion] [varchar](50) NULL,
	[isTest] [varchar](1) NULL,
	[isDeleted] [bit] NULL,
	[CorporateGroup] [varchar](50) NULL,
	[Erp] [varchar](50) NULL,
	[Version] [varchar](50) NULL,
	[FromID] [int] NULL,
	[Hash] [varchar](50) NULL,
 CONSTRAINT [PK_Head] PRIMARY KEY CLUSTERED 
(
	[PostId] DESC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
;
SET ANSI_PADDING OFF
;
/****** Object:  Table [dbo].[Line]    Script Date: 03/12/2015 14:42:50 ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
SET ANSI_PADDING ON
;
CREATE TABLE [dbo].[Line](
	[PostId] [int] NOT NULL,
	[LineId] [bigint] IDENTITY(1,1) NOT NULL,
	[LineCount] [int] NOT NULL,
	[LineNumber] [varchar](50) NULL,
	[GtinNo] [varchar](50) NULL,
	[SellerPartNo] [varchar](50) NULL,
	[BuyerPartNo] [varchar](50) NULL,
	[ManufPartNo] [varchar](50) NULL,
	[QuantityInvoiced] [varchar](50) NULL,
	[QuantityInvoicedUnit] [varchar](50) NULL,
	[QuantityDelivered] [varchar](50) NULL,
	[QuantityDeliveredUnit] [varchar](50) NULL,
	[QuantityDespatched] [varchar](50) NULL,
	[QuantityDespatchedUnit] [varchar](50) NULL,
	[QuantityReceived] [varchar](50) NULL,
	[QuantityReceivedUnit] [varchar](50) NULL,
	[LineAmount] [varchar](50) NULL,
	[Description] [varchar](50) NULL,
	[Description2] [varchar](50) NULL,
	[CreditReason] [varchar](50) NULL,
	[Revision] [varchar](50) NULL,
	[Origin] [varchar](50) NULL,
	[DelDate] [varchar](50) NULL,
	[FirstDelDate] [varchar](50) NULL,
	[LastDelDate] [varchar](50) NULL,
	[LineType] [varchar](50) NULL,
 CONSTRAINT [PK_Line] PRIMARY KEY CLUSTERED 
(
	[LineId] DESC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
;
SET ANSI_PADDING OFF
;
/****** Object:  Table [dbo].[LineAlc]    Script Date: 03/12/2015 14:42:50 ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
SET ANSI_PADDING ON
;
CREATE TABLE [dbo].[LineAlc](
	[LineId] [bigint] NOT NULL,
	[LineAlcCount] [int] NOT NULL,
	[AlcType] [varchar](50) NULL,
	[Type] [varchar](50) NULL,
	[Percentage] [varchar](50) NULL,
	[Amount] [varchar](50) NULL,
	[TaxType] [varchar](50) NULL,
	[TaxCate;ry] [varchar](50) NULL,
	[TaxRate] [varchar](50) NULL,
	[TaxAmount] [varchar](50) NULL,
	[BaseAmount] [varchar](50) NULL,
 CONSTRAINT [PK_LineAlc] PRIMARY KEY CLUSTERED 
(
	[LineId] DESC,
	[LineAlcCount] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
;
SET ANSI_PADDING OFF
;
/****** Object:  Table [dbo].[LinePri]    Script Date: 03/12/2015 14:42:50 ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
SET ANSI_PADDING ON
;
CREATE TABLE [dbo].[LinePri](
	[LineId] [bigint] NOT NULL,
	[LinePriCount] [int] NOT NULL,
	[PriceQualifier] [varchar](50) NULL,
	[PriceType] [varchar](50) NULL,
	[PriceTypeQualifier] [varchar](50) NULL,
	[LinePri] [varchar](50) NULL,
	[LinePriBase] [varchar](50) NULL,
	[LineUnit] [varchar](50) NULL,
 CONSTRAINT [PK_LinePri] PRIMARY KEY CLUSTERED 
(
	[LineId] DESC,
	[LinePriCount] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
;
SET ANSI_PADDING OFF
;
/****** Object:  Table [dbo].[LineRef]    Script Date: 03/12/2015 14:42:50 ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
SET ANSI_PADDING ON
;
CREATE TABLE [dbo].[LineRef](
	[LineId] [bigint] NOT NULL,
	[LineRefCount] [int] NOT NULL,
	[LineRefQual] [varchar](50) NULL,
	[LineRef] [varchar](200) NULL,
	[LineRefLin] [varchar](50) NULL,
	[LineRefDate] [varchar](50) NULL,
 CONSTRAINT [PK_LineRef] PRIMARY KEY CLUSTERED 
(
	[LineId] DESC,
	[LineRefCount] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
;
SET ANSI_PADDING OFF
;
/****** Object:  Table [dbo].[LineTax]    Script Date: 03/12/2015 14:42:50 ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
SET ANSI_PADDING ON
;
CREATE TABLE [dbo].[LineTax](
	[LineId] [bigint] NOT NULL,
	[LineTaxCount] [int] NOT NULL,
	[LineTaxType] [varchar](50) NULL,
	[LineTaxCategory] [varchar](50) NULL,
	[LineTaxRate] [varchar](50) NULL,
	[LineTaxAmount] [varchar](50) NULL,
	[ExemptFromTax] [varchar](50) NULL,
 CONSTRAINT [PK_LineTax] PRIMARY KEY CLUSTERED 
(
	[LineId] DESC,
	[LineTaxCount] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
;
SET ANSI_PADDING OFF
;
/****** Object:  Table [dbo].[Sum]    Script Date: 03/12/2015 14:42:50 ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
SET ANSI_PADDING ON
;
CREATE TABLE [dbo].[Sum](
	[PostId] [int] NOT NULL,
	[TotalQuantity] [varchar](50) NULL,
	[TotalLines] [varchar](50) NULL,
	[TotalAmount] [varchar](50) NULL,
	[TotalAmountTaxCur] [varchar](50) NULL,
	[LineAmount] [varchar](50) NULL,
	[TaxableAmount] [varchar](50) NULL,
	[TaxableAmountTaxCur] [varchar](50) NULL,
	[TaxableAmountExclExemption] [varchar](50) NULL,
	[TaxableAmountExclExemptionTaxCur] [varchar](50) NULL,
	[TaxAmount] [varchar](50) NULL,
	[TaxAmountTaxCur] [varchar](50) NULL,
	[AlcAmount] [varchar](50) NULL,
	[AdjustmentAmount] [varchar](50) NULL,
	[NonTaxableAmount] [varchar](50) NULL,
	[ExemptionAmount] [varchar](50) NULL,
 CONSTRAINT [PK_Sum] PRIMARY KEY CLUSTERED 
(
	[PostId] DESC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
;
SET ANSI_PADDING OFF
;
/****** Object:  Table [dbo].[SumTax]    Script Date: 03/12/2015 14:42:50 ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
SET ANSI_PADDING ON
;
CREATE TABLE [dbo].[SumTax](
	[PostId] [int] NOT NULL,
	[SumTaxCount] [int] NOT NULL,
	[SumTaxType] [varchar](50) NULL,
	[SumTaxCategory] [varchar](50) NULL,
	[SumTaxRate] [varchar](50) NULL,
	[SumTaxableAmount] [varchar](50) NULL,
	[SumTaxAmount] [varchar](50) NULL,
	[TaxCurrencyTaxAmount] [varchar](50) NULL,
 CONSTRAINT [PK_SumTax] PRIMARY KEY CLUSTERED 
(
	[PostId] DESC,
	[SumTaxCount] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
;
SET ANSI_PADDING OFF
;
/****** Object:  Table [dbo].[Tdt]    Script Date: 03/12/2015 14:42:50 ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
SET ANSI_PADDING ON
;
CREATE TABLE [dbo].[Tdt](
	[PostId] [int] NOT NULL,
	[TdtCount] [int] NOT NULL,
	[TdtMethod] [varchar](50) NULL,
	[TdtDescription] [varchar](50) NULL,
	[TdtCarrierName] [varchar](50) NULL,
 CONSTRAINT [PK_Tdt] PRIMARY KEY CLUSTERED 
(
	[PostId] DESC,
	[TdtCount] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
;
SET ANSI_PADDING OFF
;
/****** Object:  Table [dbo].[Tod]    Script Date: 03/12/2015 14:42:50 ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
SET ANSI_PADDING ON
;
CREATE TABLE [dbo].[Tod](
	[PostId] [int] NOT NULL,
	[TodCount] [int] NOT NULL,
	[TodTerms] [varchar](50) NULL,
	[TodDescription] [varchar](50) NULL,
	[TodTermsLoc] [varchar](50) NULL,
 CONSTRAINT [PK_Tod] PRIMARY KEY CLUSTERED 
(
	[PostId] DESC,
	[TodCount] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
;
SET ANSI_PADDING OFF
;
/****** Object:  Table [dbo].[Enclosure]    Script Date: 03/12/2015 14:42:50 ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
SET ANSI_PADDING ON
;
CREATE TABLE [dbo].[Enclosure](
	[PostId] [int] NOT NULL,
	[EnclosureCount] [int] NOT NULL,
	[MediaType] [varchar](50) NULL,
	[FileName] [varchar](250) NULL,
	[FileCreationDate] [varchar](50) NULL,
	[EnclosedDataFormat] [varchar](50) NULL,
	[EnclosedData] [varchar](max) NULL,
 CONSTRAINT [PK_Enclosure] PRIMARY KEY CLUSTERED 
(
	[PostId] ASC,
	[EnclosureCount] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
;
SET ANSI_PADDING OFF
;
/****** Object:  Table [dbo].[Alc]    Script Date: 03/12/2015 14:42:50 ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
SET ANSI_PADDING ON
;
CREATE TABLE [dbo].[Alc](
	[PostId] [int] NOT NULL,
	[AlcCount] [int] NOT NULL,
	[AlcType] [varchar](50) NULL,
	[Type] [varchar](50) NULL,
	[Percentage] [varchar](50) NULL,
	[BaseAmount] [varchar](50) NULL,
	[Amount] [varchar](50) NULL,
	[TaxType] [varchar](50) NULL,
	[TaxCategory] [varchar](50) NULL,
	[TaxRate] [varchar](50) NULL,
	[TaxAmount] [varchar](50) NULL,
 CONSTRAINT [PK_Alc] PRIMARY KEY CLUSTERED 
(
	[PostId] DESC,
	[AlcCount] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
;
SET ANSI_PADDING OFF
;
/****** Object:  Table [dbo].[Bet]    Script Date: 03/12/2015 14:42:50 ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
SET ANSI_PADDING ON
;
CREATE TABLE [dbo].[Bet](
	[PostId] [int] NOT NULL,
	[DueDate] [varchar](50) NULL,
	[DueDays] [varchar](50) NULL,
	[InvCurrency] [varchar](50) NULL,
	[TaxCurrency] [varchar](50) NULL,
	[TaxCurrencyRate] [varchar](50) NULL,
	[TaxCurrencyRateDate] [varchar](50) NULL,
	[ExemptFromTax] [varchar](50) NULL,
	[PenaltySurchargePercent] [varchar](50) NULL,
	[PaymentInstruction] [varchar](50) NULL,
 CONSTRAINT [PK_Bet] PRIMARY KEY CLUSTERED 
(
	[PostId] DESC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
;
SET ANSI_PADDING OFF
;
/****** Object:  Table [dbo].[Company]    Script Date: 03/12/2015 14:42:50 ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
SET ANSI_PADDING ON
;
CREATE TABLE [dbo].[Company](
	[PostId] [int] NOT NULL,
	[CompanyCount] [int] NOT NULL,
	[CompanyQual] [varchar](50) NULL,
	[PartyIdentification] [varchar](50) NULL,
	[VatNo] [varchar](50) NULL,
	[OrgNo] [varchar](50) NULL,
	[CustomerNumber] [varchar](50) NULL,
	[SellerUniqueIdentification] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[ContactName] [varchar](50) NULL,
	[ContactTel] [varchar](50) NULL,
	[ContactEmail] [varchar](50) NULL,
	[ContactFax] [varchar](50) NULL,
	[StreetName] [varchar](50) NULL,
	[AdditionalStreetName] [varchar](50) NULL,
	[ZipCode] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[Country] [varchar](50) NULL,
	[Box] [varchar](50) NULL,
	[Department] [varchar](50) NULL,
	[BankCode] [varchar](50) NULL,
	[BankName] [varchar](50) NULL,
	[BankAccount] [varchar](50) NULL,
	[Iban] [varchar](50) NULL,
	[PlusGiro] [varchar](50) NULL,
	[BankGiro] [varchar](50) NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[PostId] DESC,
	[CompanyCount] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
;
SET ANSI_PADDING OFF
;
/****** Object:  Table [dbo].[HeadRef]    Script Date: 03/12/2015 14:42:50 ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
SET ANSI_PADDING ON
;
CREATE TABLE [dbo].[HeadRef](
	[PostId] [int] NOT NULL,
	[HeadRefCount] [int] NOT NULL,
	[HeadRefQual] [varchar](50) NULL,
	[HeadRef] [varchar](200) NULL,
	[HeadRefDate] [varchar](50) NULL,
 CONSTRAINT [PK_HeadRef] PRIMARY KEY CLUSTERED 
(
	[PostId] DESC,
	[HeadRefCount] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
;
SET ANSI_PADDING OFF
;
/****** Object:  ForeignKey [FK_LineAlc_Line]    Script Date: 03/12/2015 14:42:50 ******/
ALTER TABLE [dbo].[LineAlc]  WITH CHECK ADD  CONSTRAINT [FK_LineAlc_Line] FOREIGN KEY([LineId])
REFERENCES [dbo].[Line] ([LineId])
;
ALTER TABLE [dbo].[LineAlc] CHECK CONSTRAINT [FK_LineAlc_Line]
;
/****** Object:  ForeignKey [FK_LinePri_Line]    Script Date: 03/12/2015 14:42:50 ******/
ALTER TABLE [dbo].[LinePri]  WITH CHECK ADD  CONSTRAINT [FK_LinePri_Line] FOREIGN KEY([LineId])
REFERENCES [dbo].[Line] ([LineId])
;
ALTER TABLE [dbo].[LinePri] CHECK CONSTRAINT [FK_LinePri_Line]
;
/****** Object:  ForeignKey [FK_LineRef_Line]    Script Date: 03/12/2015 14:42:50 ******/
ALTER TABLE [dbo].[LineRef]  WITH CHECK ADD  CONSTRAINT [FK_LineRef_Line] FOREIGN KEY([LineId])
REFERENCES [dbo].[Line] ([LineId])
;
ALTER TABLE [dbo].[LineRef] CHECK CONSTRAINT [FK_LineRef_Line]
;
/****** Object:  ForeignKey [FK_LineTax_Line]    Script Date: 03/12/2015 14:42:50 ******/
ALTER TABLE [dbo].[LineTax]  WITH CHECK ADD  CONSTRAINT [FK_LineTax_Line] FOREIGN KEY([LineId])
REFERENCES [dbo].[Line] ([LineId])
;
ALTER TABLE [dbo].[LineTax] CHECK CONSTRAINT [FK_LineTax_Line]
;
/****** Object:  ForeignKey [FK_Sum_Head]    Script Date: 03/12/2015 14:42:50 ******/
ALTER TABLE [dbo].[Sum]  WITH CHECK ADD  CONSTRAINT [FK_Sum_Head] FOREIGN KEY([PostId])
REFERENCES [dbo].[Head] ([PostId])
;
ALTER TABLE [dbo].[Sum] CHECK CONSTRAINT [FK_Sum_Head]
;
/****** Object:  ForeignKey [FK_SumTax_Head]    Script Date: 03/12/2015 14:42:50 ******/
ALTER TABLE [dbo].[SumTax]  WITH CHECK ADD  CONSTRAINT [FK_SumTax_Head] FOREIGN KEY([PostId])
REFERENCES [dbo].[Head] ([PostId])
;
ALTER TABLE [dbo].[SumTax] CHECK CONSTRAINT [FK_SumTax_Head]
;
/****** Object:  ForeignKey [FK_Tdt_Head]    Script Date: 03/12/2015 14:42:50 ******/
ALTER TABLE [dbo].[Tdt]  WITH CHECK ADD  CONSTRAINT [FK_Tdt_Head] FOREIGN KEY([PostId])
REFERENCES [dbo].[Head] ([PostId])
;
ALTER TABLE [dbo].[Tdt] CHECK CONSTRAINT [FK_Tdt_Head]
;
/****** Object:  ForeignKey [FK_Tod_Head]    Script Date: 03/12/2015 14:42:50 ******/
ALTER TABLE [dbo].[Tod]  WITH CHECK ADD  CONSTRAINT [FK_Tod_Head] FOREIGN KEY([PostId])
REFERENCES [dbo].[Head] ([PostId])
;
ALTER TABLE [dbo].[Tod] CHECK CONSTRAINT [FK_Tod_Head]
;
/****** Object:  ForeignKey [FK_Enclosure_Head]    Script Date: 03/12/2015 14:42:50 ******/
ALTER TABLE [dbo].[Enclosure]  WITH CHECK ADD  CONSTRAINT [FK_Enclosure_Head] FOREIGN KEY([PostId])
REFERENCES [dbo].[Head] ([PostId])
;
ALTER TABLE [dbo].[Enclosure] CHECK CONSTRAINT [FK_Enclosure_Head]
;
/****** Object:  ForeignKey [FK_Alc_Head]    Script Date: 03/12/2015 14:42:50 ******/
ALTER TABLE [dbo].[Alc]  WITH CHECK ADD  CONSTRAINT [FK_Alc_Head] FOREIGN KEY([PostId])
REFERENCES [dbo].[Head] ([PostId])
;
ALTER TABLE [dbo].[Alc] CHECK CONSTRAINT [FK_Alc_Head]
;
/****** Object:  ForeignKey [FK_Bet_Head]    Script Date: 03/12/2015 14:42:50 ******/
ALTER TABLE [dbo].[Bet]  WITH CHECK ADD  CONSTRAINT [FK_Bet_Head] FOREIGN KEY([PostId])
REFERENCES [dbo].[Head] ([PostId])
;
ALTER TABLE [dbo].[Bet] CHECK CONSTRAINT [FK_Bet_Head]
;
/****** Object:  ForeignKey [FK_Company_Head]    Script Date: 03/12/2015 14:42:50 ******/
ALTER TABLE [dbo].[Company]  WITH CHECK ADD  CONSTRAINT [FK_Company_Head] FOREIGN KEY([PostId])
REFERENCES [dbo].[Head] ([PostId])
;
ALTER TABLE [dbo].[Company] CHECK CONSTRAINT [FK_Company_Head]
;
/****** Object:  ForeignKey [FK_HeadRef_Head]    Script Date: 03/12/2015 14:42:50 ******/
ALTER TABLE [dbo].[HeadRef]  WITH CHECK ADD  CONSTRAINT [FK_HeadRef_Head] FOREIGN KEY([PostId])
REFERENCES [dbo].[Head] ([PostId])
;
ALTER TABLE [dbo].[HeadRef] CHECK CONSTRAINT [FK_HeadRef_Head]
;
/****** Object:  ForeignKey [FK_Line_Head]    Script Date: 03/12/2015 14:42:50 ******/
ALTER TABLE [dbo].[Line]  WITH CHECK ADD  CONSTRAINT [FK_Line_Head] FOREIGN KEY([PostId])
REFERENCES [dbo].[Head] ([PostId])
;
ALTER TABLE [dbo].[Line] CHECK CONSTRAINT [FK_Line_Head]
;
";
        #endregion

        #region createBillOrginal
        public static string createBillOrginal = @"
USE [Bill]
;
/****** Object:  Table [dbo].[Head]    Script Date: 03/12/2015 14:42:50 ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
SET ANSI_PADDING ON
;
CREATE TABLE [dbo].[Head](
	[PostId] [int] IDENTITY(1,1) NOT NULL,
	[IAID] [varchar](50) NULL,
	[Flow] [varchar](50) NULL,
	[InvoiceNo] [varchar](50) NULL,
	[OutputType] [varchar](50) NULL,
	[UpdateCode] [int] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[InvoiceType] [varchar](5) NULL,
	[InvoiceDate] [varchar](50) NULL,
	[RealDelDate] [varchar](50) NULL,
	[RealDelShip] [varchar](50) NULL,
	[HorizonStartDate] [varchar](50) NULL,
	[HorizonEndDate] [varchar](50) NULL,
	[PeriodFrom] [varchar](50) NULL,
	[PeriodTo] [varchar](50) NULL,
	[CreditReason] [varchar](50) NULL,
	[MaterialType] [varchar](50) NULL,
	[GUID] [varchar](50) NULL,
	[Timestamp] [varchar](50) NULL,
	[ErpVersion] [varchar](50) NULL,
	[isTest] [varchar](1) NULL,
	[isDeleted] [bit] NULL,
	[CorporateGroup] [varchar](50) NULL,
	[Erp] [varchar](50) NULL,
	[Version] [varchar](50) NULL,
	[FromID] [int] NULL,
	[Hash] [varchar](50) NULL,
 CONSTRAINT [PK_Head] PRIMARY KEY CLUSTERED 
(
	[PostId] DESC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
;
SET ANSI_PADDING OFF
;
/****** Object:  Table [dbo].[Line]    Script Date: 03/12/2015 14:42:50 ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
SET ANSI_PADDING ON
;
CREATE TABLE [dbo].[Line](
	[PostId] [int] NOT NULL,
	[LineId] [bigint] IDENTITY(1,1) NOT NULL,
	[LineCount] [int] NOT NULL,
	[LineNumber] [varchar](50) NULL,
	[GtinNo] [varchar](50) NULL,
	[SellerPartNo] [varchar](50) NULL,
	[BuyerPartNo] [varchar](50) NULL,
	[ManufPartNo] [varchar](50) NULL,
	[QuantityInvoiced] [varchar](50) NULL,
	[QuantityInvoicedUnit] [varchar](50) NULL,
	[QuantityDelivered] [varchar](50) NULL,
	[QuantityDeliveredUnit] [varchar](50) NULL,
	[QuantityDespatched] [varchar](50) NULL,
	[QuantityDespatchedUnit] [varchar](50) NULL,
	[QuantityReceived] [varchar](50) NULL,
	[QuantityReceivedUnit] [varchar](50) NULL,
	[LineAmount] [varchar](50) NULL,
	[Description] [varchar](50) NULL,
	[Description2] [varchar](50) NULL,
	[CreditReason] [varchar](50) NULL,
	[Revision] [varchar](50) NULL,
	[Origin] [varchar](50) NULL,
	[DelDate] [varchar](50) NULL,
	[FirstDelDate] [varchar](50) NULL,
	[LastDelDate] [varchar](50) NULL,
	[LineType] [varchar](50) NULL,
 CONSTRAINT [PK_Line] PRIMARY KEY CLUSTERED 
(
	[LineId] DESC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
;
SET ANSI_PADDING OFF
;
/****** Object:  Table [dbo].[LineAlc]    Script Date: 03/12/2015 14:42:50 ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
SET ANSI_PADDING ON
;
CREATE TABLE [dbo].[LineAlc](
	[LineId] [bigint] NOT NULL,
	[LineAlcCount] [int] NOT NULL,
	[AlcType] [varchar](50) NULL,
	[Type] [varchar](50) NULL,
	[Percentage] [varchar](50) NULL,
	[Amount] [varchar](50) NULL,
	[TaxType] [varchar](50) NULL,
	[TaxCate;ry] [varchar](50) NULL,
	[TaxRate] [varchar](50) NULL,
	[TaxAmount] [varchar](50) NULL,
	[BaseAmount] [varchar](50) NULL,
 CONSTRAINT [PK_LineAlc] PRIMARY KEY CLUSTERED 
(
	[LineId] DESC,
	[LineAlcCount] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
;
SET ANSI_PADDING OFF
;
/****** Object:  Table [dbo].[LinePri]    Script Date: 03/12/2015 14:42:50 ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
SET ANSI_PADDING ON
;
CREATE TABLE [dbo].[LinePri](
	[LineId] [bigint] NOT NULL,
	[LinePriCount] [int] NOT NULL,
	[PriceQualifier] [varchar](50) NULL,
	[PriceType] [varchar](50) NULL,
	[PriceTypeQualifier] [varchar](50) NULL,
	[LinePri] [varchar](50) NULL,
	[LinePriBase] [varchar](50) NULL,
	[LineUnit] [varchar](50) NULL,
 CONSTRAINT [PK_LinePri] PRIMARY KEY CLUSTERED 
(
	[LineId] DESC,
	[LinePriCount] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
;
SET ANSI_PADDING OFF
;
/****** Object:  Table [dbo].[LineRef]    Script Date: 03/12/2015 14:42:50 ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
SET ANSI_PADDING ON
;
CREATE TABLE [dbo].[LineRef](
	[LineId] [bigint] NOT NULL,
	[LineRefCount] [int] NOT NULL,
	[LineRefQual] [varchar](50) NULL,
	[LineRef] [varchar](200) NULL,
	[LineRefLin] [varchar](50) NULL,
	[LineRefDate] [varchar](50) NULL,
 CONSTRAINT [PK_LineRef] PRIMARY KEY CLUSTERED 
(
	[LineId] DESC,
	[LineRefCount] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
;
SET ANSI_PADDING OFF
;
/****** Object:  Table [dbo].[LineTax]    Script Date: 03/12/2015 14:42:50 ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
SET ANSI_PADDING ON
;
CREATE TABLE [dbo].[LineTax](
	[LineId] [bigint] NOT NULL,
	[LineTaxCount] [int] NOT NULL,
	[LineTaxType] [varchar](50) NULL,
	[LineTaxCategory] [varchar](50) NULL,
	[LineTaxRate] [varchar](50) NULL,
	[LineTaxAmount] [varchar](50) NULL,
	[ExemptFromTax] [varchar](50) NULL,
 CONSTRAINT [PK_LineTax] PRIMARY KEY CLUSTERED 
(
	[LineId] DESC,
	[LineTaxCount] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
;
SET ANSI_PADDING OFF
;
/****** Object:  Table [dbo].[Sum]    Script Date: 03/12/2015 14:42:50 ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
SET ANSI_PADDING ON
;
CREATE TABLE [dbo].[Sum](
	[PostId] [int] NOT NULL,
	[TotalQuantity] [varchar](50) NULL,
	[TotalLines] [varchar](50) NULL,
	[TotalAmount] [varchar](50) NULL,
	[TotalAmountTaxCur] [varchar](50) NULL,
	[LineAmount] [varchar](50) NULL,
	[TaxableAmount] [varchar](50) NULL,
	[TaxableAmountTaxCur] [varchar](50) NULL,
	[TaxableAmountExclExemption] [varchar](50) NULL,
	[TaxableAmountExclExemptionTaxCur] [varchar](50) NULL,
	[TaxAmount] [varchar](50) NULL,
	[TaxAmountTaxCur] [varchar](50) NULL,
	[AlcAmount] [varchar](50) NULL,
	[AdjustmentAmount] [varchar](50) NULL,
	[NonTaxableAmount] [varchar](50) NULL,
	[ExemptionAmount] [varchar](50) NULL,
 CONSTRAINT [PK_Sum] PRIMARY KEY CLUSTERED 
(
	[PostId] DESC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
;
SET ANSI_PADDING OFF
;
/****** Object:  Table [dbo].[SumTax]    Script Date: 03/12/2015 14:42:50 ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
SET ANSI_PADDING ON
;
CREATE TABLE [dbo].[SumTax](
	[PostId] [int] NOT NULL,
	[SumTaxCount] [int] NOT NULL,
	[SumTaxType] [varchar](50) NULL,
	[SumTaxCategory] [varchar](50) NULL,
	[SumTaxRate] [varchar](50) NULL,
	[SumTaxableAmount] [varchar](50) NULL,
	[SumTaxAmount] [varchar](50) NULL,
	[TaxCurrencyTaxAmount] [varchar](50) NULL,
 CONSTRAINT [PK_SumTax] PRIMARY KEY CLUSTERED 
(
	[PostId] DESC,
	[SumTaxCount] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
;
SET ANSI_PADDING OFF
;
/****** Object:  Table [dbo].[Tdt]    Script Date: 03/12/2015 14:42:50 ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
SET ANSI_PADDING ON
;
CREATE TABLE [dbo].[Tdt](
	[PostId] [int] NOT NULL,
	[TdtCount] [int] NOT NULL,
	[TdtMethod] [varchar](50) NULL,
	[TdtDescription] [varchar](50) NULL,
	[TdtCarrierName] [varchar](50) NULL,
 CONSTRAINT [PK_Tdt] PRIMARY KEY CLUSTERED 
(
	[PostId] DESC,
	[TdtCount] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
;
SET ANSI_PADDING OFF
;
/****** Object:  Table [dbo].[Tod]    Script Date: 03/12/2015 14:42:50 ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
SET ANSI_PADDING ON
;
CREATE TABLE [dbo].[Tod](
	[PostId] [int] NOT NULL,
	[TodCount] [int] NOT NULL,
	[TodTerms] [varchar](50) NULL,
	[TodDescription] [varchar](50) NULL,
	[TodTermsLoc] [varchar](50) NULL,
 CONSTRAINT [PK_Tod] PRIMARY KEY CLUSTERED 
(
	[PostId] DESC,
	[TodCount] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
;
SET ANSI_PADDING OFF
;
/****** Object:  Table [dbo].[Enclosure]    Script Date: 03/12/2015 14:42:50 ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
SET ANSI_PADDING ON
;
CREATE TABLE [dbo].[Enclosure](
	[PostId] [int] NOT NULL,
	[EnclosureCount] [int] NOT NULL,
	[MediaType] [varchar](50) NULL,
	[FileName] [varchar](250) NULL,
	[FileCreationDate] [varchar](50) NULL,
	[EnclosedDataFormat] [varchar](50) NULL,
	[EnclosedData] [varchar](max) NULL,
 CONSTRAINT [PK_Enclosure] PRIMARY KEY CLUSTERED 
(
	[PostId] ASC,
	[EnclosureCount] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
;
SET ANSI_PADDING OFF
;
/****** Object:  Table [dbo].[Alc]    Script Date: 03/12/2015 14:42:50 ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
SET ANSI_PADDING ON
;
CREATE TABLE [dbo].[Alc](
	[PostId] [int] NOT NULL,
	[AlcCount] [int] NOT NULL,
	[AlcType] [varchar](50) NULL,
	[Type] [varchar](50) NULL,
	[Percentage] [varchar](50) NULL,
	[BaseAmount] [varchar](50) NULL,
	[Amount] [varchar](50) NULL,
	[TaxType] [varchar](50) NULL,
	[TaxCategory] [varchar](50) NULL,
	[TaxRate] [varchar](50) NULL,
	[TaxAmount] [varchar](50) NULL,
 CONSTRAINT [PK_Alc] PRIMARY KEY CLUSTERED 
(
	[PostId] DESC,
	[AlcCount] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
;
SET ANSI_PADDING OFF
;
/****** Object:  Table [dbo].[Bet]    Script Date: 03/12/2015 14:42:50 ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
SET ANSI_PADDING ON
;
CREATE TABLE [dbo].[Bet](
	[PostId] [int] NOT NULL,
	[DueDate] [varchar](50) NULL,
	[DueDays] [varchar](50) NULL,
	[InvCurrency] [varchar](50) NULL,
	[TaxCurrency] [varchar](50) NULL,
	[TaxCurrencyRate] [varchar](50) NULL,
	[TaxCurrencyRateDate] [varchar](50) NULL,
	[ExemptFromTax] [varchar](50) NULL,
	[PenaltySurchargePercent] [varchar](50) NULL,
	[PaymentInstruction] [varchar](50) NULL,
 CONSTRAINT [PK_Bet] PRIMARY KEY CLUSTERED 
(
	[PostId] DESC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
;
SET ANSI_PADDING OFF
;
/****** Object:  Table [dbo].[Company]    Script Date: 03/12/2015 14:42:50 ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
SET ANSI_PADDING ON
;
CREATE TABLE [dbo].[Company](
	[PostId] [int] NOT NULL,
	[CompanyCount] [int] NOT NULL,
	[CompanyQual] [varchar](50) NULL,
	[PartyIdentification] [varchar](50) NULL,
	[VatNo] [varchar](50) NULL,
	[OrgNo] [varchar](50) NULL,
	[CustomerNumber] [varchar](50) NULL,
	[SellerUniqueIdentification] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[ContactName] [varchar](50) NULL,
	[ContactTel] [varchar](50) NULL,
	[ContactEmail] [varchar](50) NULL,
	[ContactFax] [varchar](50) NULL,
	[StreetName] [varchar](50) NULL,
	[AdditionalStreetName] [varchar](50) NULL,
	[ZipCode] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[Country] [varchar](50) NULL,
	[Box] [varchar](50) NULL,
	[Department] [varchar](50) NULL,
	[BankCode] [varchar](50) NULL,
	[BankName] [varchar](50) NULL,
	[BankAccount] [varchar](50) NULL,
	[Iban] [varchar](50) NULL,
	[PlusGiro] [varchar](50) NULL,
	[BankGiro] [varchar](50) NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[PostId] DESC,
	[CompanyCount] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
;
SET ANSI_PADDING OFF
;
/****** Object:  Table [dbo].[HeadRef]    Script Date: 03/12/2015 14:42:50 ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
SET ANSI_PADDING ON
;
CREATE TABLE [dbo].[HeadRef](
	[PostId] [int] NOT NULL,
	[HeadRefCount] [int] NOT NULL,
	[HeadRefQual] [varchar](50) NULL,
	[HeadRef] [varchar](200) NULL,
	[HeadRefDate] [varchar](50) NULL,
 CONSTRAINT [PK_HeadRef] PRIMARY KEY CLUSTERED 
(
	[PostId] DESC,
	[HeadRefCount] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
;
SET ANSI_PADDING OFF
;
/****** Object:  Trigger [CreateDate]    Script Date: 03/12/2015 14:42:50 ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE trigger [dbo].[CreateDate]
ON [dbo].[Head]
FOR INSERT
AS

Begin

Update HEAD
set CreateDate = getdate ()
from inserted i, HEAD a
where i.PostId = a.PostId

End
;
/****** Object:  Trigger [UpdateDate]    Script Date: 03/12/2015 14:42:50 ******/
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE trigger [dbo].[UpdateDate]
ON [dbo].[Head]
FOR INSERT, UPDATE
AS

Begin

Update HEAD
set UpdateDate = getdate ()
from inserted i, HEAD a
where i.PostId = a.PostId

End
;
/****** Object:  ForeignKey [FK_LineAlc_Line]    Script Date: 03/12/2015 14:42:50 ******/
ALTER TABLE [dbo].[LineAlc]  WITH CHECK ADD  CONSTRAINT [FK_LineAlc_Line] FOREIGN KEY([LineId])
REFERENCES [dbo].[Line] ([LineId])
;
ALTER TABLE [dbo].[LineAlc] CHECK CONSTRAINT [FK_LineAlc_Line]
;
/****** Object:  ForeignKey [FK_LinePri_Line]    Script Date: 03/12/2015 14:42:50 ******/
ALTER TABLE [dbo].[LinePri]  WITH CHECK ADD  CONSTRAINT [FK_LinePri_Line] FOREIGN KEY([LineId])
REFERENCES [dbo].[Line] ([LineId])
;
ALTER TABLE [dbo].[LinePri] CHECK CONSTRAINT [FK_LinePri_Line]
;
/****** Object:  ForeignKey [FK_LineRef_Line]    Script Date: 03/12/2015 14:42:50 ******/
ALTER TABLE [dbo].[LineRef]  WITH CHECK ADD  CONSTRAINT [FK_LineRef_Line] FOREIGN KEY([LineId])
REFERENCES [dbo].[Line] ([LineId])
;
ALTER TABLE [dbo].[LineRef] CHECK CONSTRAINT [FK_LineRef_Line]
;
/****** Object:  ForeignKey [FK_LineTax_Line]    Script Date: 03/12/2015 14:42:50 ******/
ALTER TABLE [dbo].[LineTax]  WITH CHECK ADD  CONSTRAINT [FK_LineTax_Line] FOREIGN KEY([LineId])
REFERENCES [dbo].[Line] ([LineId])
;
ALTER TABLE [dbo].[LineTax] CHECK CONSTRAINT [FK_LineTax_Line]
;
/****** Object:  ForeignKey [FK_Sum_Head]    Script Date: 03/12/2015 14:42:50 ******/
ALTER TABLE [dbo].[Sum]  WITH CHECK ADD  CONSTRAINT [FK_Sum_Head] FOREIGN KEY([PostId])
REFERENCES [dbo].[Head] ([PostId])
;
ALTER TABLE [dbo].[Sum] CHECK CONSTRAINT [FK_Sum_Head]
;
/****** Object:  ForeignKey [FK_SumTax_Head]    Script Date: 03/12/2015 14:42:50 ******/
ALTER TABLE [dbo].[SumTax]  WITH CHECK ADD  CONSTRAINT [FK_SumTax_Head] FOREIGN KEY([PostId])
REFERENCES [dbo].[Head] ([PostId])
;
ALTER TABLE [dbo].[SumTax] CHECK CONSTRAINT [FK_SumTax_Head]
;
/****** Object:  ForeignKey [FK_Tdt_Head]    Script Date: 03/12/2015 14:42:50 ******/
ALTER TABLE [dbo].[Tdt]  WITH CHECK ADD  CONSTRAINT [FK_Tdt_Head] FOREIGN KEY([PostId])
REFERENCES [dbo].[Head] ([PostId])
;
ALTER TABLE [dbo].[Tdt] CHECK CONSTRAINT [FK_Tdt_Head]
;
/****** Object:  ForeignKey [FK_Tod_Head]    Script Date: 03/12/2015 14:42:50 ******/
ALTER TABLE [dbo].[Tod]  WITH CHECK ADD  CONSTRAINT [FK_Tod_Head] FOREIGN KEY([PostId])
REFERENCES [dbo].[Head] ([PostId])
;
ALTER TABLE [dbo].[Tod] CHECK CONSTRAINT [FK_Tod_Head]
;
/****** Object:  ForeignKey [FK_Enclosure_Head]    Script Date: 03/12/2015 14:42:50 ******/
ALTER TABLE [dbo].[Enclosure]  WITH CHECK ADD  CONSTRAINT [FK_Enclosure_Head] FOREIGN KEY([PostId])
REFERENCES [dbo].[Head] ([PostId])
;
ALTER TABLE [dbo].[Enclosure] CHECK CONSTRAINT [FK_Enclosure_Head]
;
/****** Object:  ForeignKey [FK_Alc_Head]    Script Date: 03/12/2015 14:42:50 ******/
ALTER TABLE [dbo].[Alc]  WITH CHECK ADD  CONSTRAINT [FK_Alc_Head] FOREIGN KEY([PostId])
REFERENCES [dbo].[Head] ([PostId])
;
ALTER TABLE [dbo].[Alc] CHECK CONSTRAINT [FK_Alc_Head]
;
/****** Object:  ForeignKey [FK_Bet_Head]    Script Date: 03/12/2015 14:42:50 ******/
ALTER TABLE [dbo].[Bet]  WITH CHECK ADD  CONSTRAINT [FK_Bet_Head] FOREIGN KEY([PostId])
REFERENCES [dbo].[Head] ([PostId])
;
ALTER TABLE [dbo].[Bet] CHECK CONSTRAINT [FK_Bet_Head]
;
/****** Object:  ForeignKey [FK_Company_Head]    Script Date: 03/12/2015 14:42:50 ******/
ALTER TABLE [dbo].[Company]  WITH CHECK ADD  CONSTRAINT [FK_Company_Head] FOREIGN KEY([PostId])
REFERENCES [dbo].[Head] ([PostId])
;
ALTER TABLE [dbo].[Company] CHECK CONSTRAINT [FK_Company_Head]
;
/****** Object:  ForeignKey [FK_HeadRef_Head]    Script Date: 03/12/2015 14:42:50 ******/
ALTER TABLE [dbo].[HeadRef]  WITH CHECK ADD  CONSTRAINT [FK_HeadRef_Head] FOREIGN KEY([PostId])
REFERENCES [dbo].[Head] ([PostId])
;
ALTER TABLE [dbo].[HeadRef] CHECK CONSTRAINT [FK_HeadRef_Head]
;
/****** Object:  ForeignKey [FK_Line_Head]    Script Date: 03/12/2015 14:42:50 ******/
ALTER TABLE [dbo].[Line]  WITH CHECK ADD  CONSTRAINT [FK_Line_Head] FOREIGN KEY([PostId])
REFERENCES [dbo].[Head] ([PostId])
;
ALTER TABLE [dbo].[Line] CHECK CONSTRAINT [FK_Line_Head]
;
";
        #endregion

        #region createTrigger1
        public static string createTrigger1 = @"
CREATE trigger [dbo].[CreateDate]
ON [dbo].[Head]
FOR INSERT
AS

Begin

Update HEAD
set CreateDate = getdate ()
from inserted i, HEAD a
where i.PostId = a.PostId

End
;";
        #endregion

        #region createTrigger2
        public static string createTrigger2 = @"CREATE trigger [dbo].[UpdateDate]
ON [dbo].[Head]
FOR INSERT, UPDATE
AS

Begin

Update HEAD
set UpdateDate = getdate ()
from inserted i, HEAD a
where i.PostId = a.PostId

End
;";
        #endregion

    }
}

