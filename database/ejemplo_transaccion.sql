BEGIN TRY
    BEGIN TRANSACTION
		
		PRINT 'INSERT [Facturas]'

        INSERT INTO [dbo].[Facturas]
					([nro_factura],[fecha],[cliente],[tipoFactura],[subtotal],[descuento],[borrado])
		VALUES (458,GETDATE(),11,1,100,0,0)


		PRINT 'INSERT [FacturasDetalle]'

		INSERT INTO [dbo].[FacturasDetalle]
					([id_factura],[id_producto],[precio_unitario],[cantidad],[borrado])
		VALUES (@@IDENTITY,1,100, 4001,0)

		PRINT 'COMMIT'

        COMMIT
END TRY
BEGIN CATCH
	PRINT 'ROLLBACK'
    ROLLBACK
END CATCH