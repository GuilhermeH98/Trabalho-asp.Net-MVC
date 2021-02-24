use master
go

drop database DB_A6AD05_N2LPBD
go

create database DB_A6AD05_N2LPBD
go

use DB_A6AD05_N2LPBD
go

create table Usuario
(
	idUsuario int primary key identity(1,1),
	userLogin varchar(max),
	senha varchar(max),
	nickname varchar(50),
	Administrador bit
)

create table Categoria
(
	idCategoria int primary key identity(1,1),
	descricaoCategoria varchar(max)
)

create table Publicadora
(
	idPublicadora int primary key  identity(1,1),
	nomePublicadora varchar(max)
)

create table Desenvolvedora
(
	idDesenvolvedora int primary key  identity(1,1),
	nomeDesenvolvedora varchar(max)
)
go

create table Jogo
(
	idJogo int primary key NONCLUSTERED not null identity(1,1),
	nomeJogo varchar(max),
	precoJogo decimal(6,2),
	descricaoJogo varchar(max),
	idCategoria int foreign key references Categoria(idCategoria),
	idPublicadora int foreign key references Publicadora(idPublicadora),
	idDesenvolvedora int foreign key references Desenvolvedora(idDesenvolvedora),
	imgJogo varbinary(max),
	quantVendida int
)
go

create table Compra
(
	idCompra int primary key identity(1,1),
	precoTotal decimal(8,2),
	formaPagamento char,
	dataCompra smalldatetime,
	idUsuario int foreign key references usuario(idUsuario)
)

create table itemCarrinho
(
	idUsuario int foreign key references usuario(idUsuario),
	idJogo int foreign key references Jogo(idJogo),
	precoItem decimal(6,2),
	dataAdicao smalldatetime,
	constraint ItensCarrinhoPK primary key (idUsuario, idJogo)
)

create table itemBiblioteca
(
	idUsuario int foreign key references usuario(idUsuario),
	idJogo int foreign key references Jogo(idJogo),
	tempoJogo bigint,													--É guardado em ticks
	constraint ItensBibliotecaPK primary key (idUsuario, idJogo)
)

create table itemListaDesejos
(
	idUsuario int foreign key references usuario(idUsuario),
	idJogo int foreign key references Jogo(idJogo),
	dataAdicao smalldatetime,
	constraint ItensDesejosPK primary key (idUsuario, idJogo)
)
go

create table ItensCompra
(
	idCompra int foreign key references Compra(idCompra),
	idJogo int foreign key references Jogo(idJogo),
	precoItem decimal(6,2),
	constraint ItensCompraPK primary key (idCompra, idJogo)
)
go

create procedure spInsert_Jogo (@id int, @nome varchar(max),@preco decimal (6,2),@descricao varchar(max),@idcategoria int, @idpublicadora int, @iddesenvolvedora int, @imgJogo varbinary(max))
as 
begin
     insert into Jogo(nomeJogo, precoJogo, descricaoJogo, idCategoria, idPublicadora, idDesenvolvedora, imgJogo) values (@nome, @preco, @descricao ,@idcategoria ,@idpublicadora ,@iddesenvolvedora, @imgJogo)
end
go

create procedure spUpdate_Jogo (@id int, @nome varchar(max),@preco decimal (6,2),@descricao varchar(max),@idcategoria int, @idpublicadora int, @iddesenvolvedora int, @imgJogo varbinary(max))
as
begin
UPDATE jogo set nomejogo = @nome, precojogo = @preco, descricaoJogo = @descricao, idCategoria = @idcategoria, idPublicadora = @idpublicadora, idDesenvolvedora = @iddesenvolvedora, imgJogo = @imgJogo
where idJogo = @id
end
go

create procedure spDelete (@id int, @tabela varchar(max))
as
begin
    declare @sql varchar(max)
	set @sql = 'delete ' + @tabela + ' where id' + @tabela + ' = ' + convert(varchar(max),@id)
	exec (@sql)	
end
go

/***********/ --Alteração na versão 4
create procedure spConsulta_Usuario (@login varchar(max), @senha varchar(max)) as
begin
	select * from vw_usuarios u where u.userLogin = @login and u.senha = @senha
end
go
/***********/

create procedure spInsert_Usuario (@Id int, @UserLogin varchar(max), @Senha varchar(max), @Nickname varchar(max), @Administrador bit) as
begin
	insert into Usuario values (@UserLogin, @Senha, @Nickname, @Administrador)
end
go

create procedure spInsert_Categoria (@Id int, @Descricao varchar(max)) as
begin
	insert into Categoria values (@Descricao)
end
go

create procedure spListagem (@tabela varchar(max),@ordem varchar(max)) as
begin
	exec('select * from ' + @tabela +
		 ' order by ' + @ordem)
end
go

create procedure spInsert_Desenvolvedora (@Id int, @NomeDesenvolvedora varchar(max)) as
begin
	insert into Desenvolvedora values (@NomeDesenvolvedora)
end
go

create procedure spInsert_Publicadora (@Id int, @NomePublicadora varchar(max)) as
begin
	insert into Publicadora values (@NomePublicadora)
end
go

create procedure spConsulta (@id int ,@tabela varchar(max)) as
begin
	declare @sql varchar(max);
	set @sql = 'select * from ' + @tabela +
			   ' where id' + @tabela + ' = ' + cast(@id as varchar(max))
	exec(@sql)
end
go

create procedure SpUpdate_Publicadora (@Id int, @NomePublicadora varchar(max)) as
begin UPDATE
      Publicadora set nomePublicadora = @NomePublicadora where idPublicadora = @Id
end
go

/***********/ --Alteração na versão 4
/***********/ --Alteração na versão 9
create procedure spInsert_Compra (@id int, @formapagamento char, @idUsuario int) as
begin
     insert into Compra (formaPagamento, idUsuario) values (@formapagamento, @idUsuario)
end
go
/***********/

create procedure spUpdate_Usuario (@Id int, @UserLogin varchar(max), @Senha varchar(max), @Nickname varchar(max), @Administrador bit) as
begin UPDATE
       usuario set userlogin = @UserLogin, senha = @senha, nickname = @Nickname 
	   where idUsuario = @id
end
go

create procedure spUpdate_Categoria (@id int, @descricao varchar(max)) as
begin UPDATE
      Categoria set descricaoCategoria = @descricao where idCategoria = @id
end
go

create procedure spUpdate_Desenvolvedora (@id int, @NomeDesenvolvedora varchar(max)) as
begin UPDATE
     Desenvolvedora set nomeDesenvolvedora = @NomeDesenvolvedora where idDesenvolvedora = @id
end
go

/***********/ --Alteração na versão 4
create procedure spInsert_ItensCompra (@idCompra int, @idJogo int, @preco decimal(6,2) ) as
begin
	insert into ItensCompra values(@idCompra, @idJogo, @preco)
end
go

create procedure spConsulta_Biblioteca (@idUsuario int) as
begin
	select j.* from Usuario u inner join Compra c on u.idUsuario = c.idUsuario inner join ItensCompra i on i.idCompra = c.idCompra inner join Jogo j on j.idJogo = i.idJogo where u.idUsuario = @idUsuario
end
go

/***********/ --Alteração na versão 6
create trigger trg_carrinhoEmCompra on compra
for INSERT as
begin
     declare @idCompra int = (select idCompra from inserted);
	 declare @idUsuario int = (select idUsuario from inserted);

	 insert into ItensCompra select idcompra, idJogo, precoItem from Compra c inner join itemCarrinho i on c.idUsuario  = i.idUsuario and c.idCompra = @idCompra
	 
	 delete itemCarrinho where idUsuario = @idUsuario

end
go

/***********/ --Alteração na versão 7
create procedure spListagemCarrinho (@idUsuario int) as
begin
	select * from itemCarrinho where idUsuario = @idUsuario
end
go

/***********/ --Alteração na versão 9
create procedure spInsert_ItemCarrinho (@IdJogo int, @IdUsuario int, @preco decimal(6,2)) as
begin
	insert into itemCarrinho(idUsuario, idJogo, precoItem) values(@IdUsuario, @IdJogo, @preco)
end
go
/***********/

/***********/ --Alteração na versão 8

create trigger trg_PrecoTotalCompra on itensCompra
for insert as
begin
	declare @idCompra int = (select distinct idCompra from inserted)
	declare @precoTotal decimal (8,2)

	set @precoTotal = (select sum(precoItem) from ItensCompra where idCompra = @idCompra)

	update Compra set precoTotal = @precoTotal where idCompra = @idCompra
end
go

create trigger trg_RemoveCompra on compra
instead of delete as
begin
	declare @idCompra int = (select idCompra from deleted)

	delete from ItensCompra where idCompra = @idCompra
	delete from Compra where idCompra = @idCompra
end
go

/***********/ --Alteração na versão 9
create trigger trg_DataCarrinho on itemCarrinho
for insert as
begin
	declare @idUsuario int = (select idUsuario from inserted)
	declare @idJogo int = (select idJogo from inserted)

	update itemCarrinho set dataAdicao = GETDATE() where idUsuario = @idUsuario and idJogo = @idJogo
end
go

create trigger trg_DataCompra on compra
for insert as
begin
	declare @id int = (select idCompra from inserted)

	update compra set dataCompra = GETDATE() where idCompra =@id
end
go

/***********/ --Alteração na versão 10

create procedure sp_PesquisaCompras (@idUsuario int, @dataInicio datetime, @dataFim datetime, @precoInicial decimal (8,2), @precoFinal decimal (8,2)) as
begin
	declare @sql varchar(max)
	set @sql = 'select * from Compra where idUsuario = ' + convert(varchar(max), @idUsuario)
	
	if (@dataInicio is not null and @dataFim is not null) 
		set @sql += ' and dataCompra between ''' + convert(varchar(max), @dataInicio) + ''' and ''' + convert(varchar(max), @dataFim) + ''''
	else if (@dataInicio is not null)
		set @sql += ' and dataCompra > ''' + convert(varchar(max), @dataInicio) + ''''
	else if (@dataFim is not null)
		set @sql += ' and dataCompra < ''' + convert(varchar(max), @dataFim) + ''''


	if (@precoInicial is not null and @precoFinal is not null)
		set @sql += ' and precoTotal between ' + convert(varchar(max), @precoInicial) + ' and ' + convert(varchar(max), @precoFinal)
	else if (@precoInicial is not null)
		set @sql += ' and precoTotal > ' + convert(varchar(max), @precoInicial)
	else if (@precoFinal is not null)
		set @sql += ' and precoTotal < ' + convert(varchar(max), @precoFinal)

	exec (@sql)
end
go

create procedure sp_PesquisaUsuarios (@Nome varchar(max), @Tipo int) as
begin
	declare @sql varchar(max)
	set @sql = 'select * from vw_usuarios where nickname like ''%' + @Nome + '%'''

	if(@Tipo = 1)
		set @sql += ' and Administrador = 0'
	else if (@Tipo = 2)
		set @sql += ' and Administrador = 1'

	print @sql
	exec (@sql)
end
go

/***********/ --Alteração na versão 11

create procedure sp_pesquisaJogos (@Nome varchar(max), @Preco decimal(6,2), @Categoria int, @Publicadora int, @Desenvolvedora int) as
begin
	declare @idJogo int

	declare cursor_jogos cursor for
		select idJogo from Jogo

	open cursor_jogos

	fetch next from cursor_jogos into @idJogo

	while @@FETCH_STATUS = 0
	begin
		declare @quant int
		set @quant = (select count(*) from Compra c inner join ItensCompra i on c.idCompra = i.idCompra inner join Jogo j on i.idJogo = j.idJogo where j.idJogo = @idJogo)

		update Jogo set quantVendida = @quant where idJogo = @idJogo

		fetch next from cursor_jogos into @idJogo
	end	

	declare @sql varchar(max)
	set @sql = 'select * from Jogo where nomeJogo like ''%' + @Nome + '%'''

	if (@preco is not null)
		set @sql += ' and precoJogo < ' + Convert(varchar(max), @Preco)

	if (@Categoria > 0)
		set @sql += ' and idCategoria = ' + Convert(varchar(max), @Categoria)

	if (@Publicadora > 0)
		set @sql += ' and idPublicadora = ' + Convert(varchar(max), @Publicadora)

	if (@Desenvolvedora > 0)
		set @sql += ' and idDesenvolvedora = ' + Convert(varchar(max), @Desenvolvedora)

	set @sql += 'order by quantVendida'

	print @sql
	exec (@sql)

	close cursor_jogos
	deallocate cursor_jogos

end
go

/***********/ --Alteração na versão 12

create procedure spListagemItensCompra (@idCompra int) as
begin
	select j.idJogo, j.nomeJogo from ItensCompra i inner join fnc_TrazJogoSemImagem() j on i.idJogo = j.idJogo where idCompra = @idCompra
end
go

create procedure spDeleteItemCarrinho (@idUsuario int, @idJogo int)
as
begin
    delete itemCarrinho where idUsuario = @idUsuario and idJogo = @idJogo
end
go

create function fnc_TrazJogoSemImagem
()
Returns table as return
(
	select idJogo, nomeJogo, precoJogo, descricaoJogo, idCategoria, idPublicadora, idDesenvolvedora, null as 'imgJogo' from Jogo
)
go

create view vw_usuarios as
select * from Usuario
go

create clustered index ix_JogosPreco 
on Jogo (precoJogo)

create nonclustered index ix_UsuariosNome
on Usuario (nickname)
go

create trigger trg_DeleteUsuario on usuario instead of delete as
begin
	declare @id int = (select idUsuario from deleted)

	delete itemCarrinho where idUsuario = @Id
	delete itemBiblioteca where idUsuario = @Id
	delete itemListaDesejos where idUsuario = @id
	
	while ((select count(*) from Compra where idUsuario = @id) > 0) --Irá continuar no loop até todos os registros de compras serem deletados
	begin
		declare @idCompra int = (select top(1) idCompra from Compra where idUsuario = @id) --Irá pegar o Id apenas de uma compra
		delete Compra where idCompra = @idCompra --Apaga aquela compra (Dessa forma, a trigger das compras funcionará normalmente)
	end

	delete Usuario where idUsuario = @id
end