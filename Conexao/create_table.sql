USE [tetris]
GO

/****** Object:  Table [dbo].[pontuacao]    Script Date: 16/07/2021 08:28:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[pontuacao](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [nvarchar](50) NOT NULL,
	[score] [int] NOT NULL,
	[nivel] [int] NOT NULL,
	[tempo_jogo] [time](7) NOT NULL,
	[qtd_pecas] [int] NOT NULL,
	[data_score] [datetime] NOT NULL,
	[tabuleiro] [image] NOT NULL,
 CONSTRAINT [PK_pontuacao] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

