Public Class Form1
    Const peso_vs_dolar As Double = 3782.66
    'Variables descriptivas
    'Se crea una variable que contiene el tipo de recuerdo según la cantiad de niños
    'False representa un piñatica y true representa Piñata
    Dim tipo_de_recuerdo As Boolean = False
    Dim tipo_de_comida As String
    Dim tipo_de_moneda As Boolean 'true representa peso colombiano y false balboa

    'Variable del costo de la fiesta
    Dim total_A_Pagar As Double
    Dim precio_total_de_comida As Double
    Dim precio_de_comida As Double

    'Variables de recuerdos
    Dim precio_de_recuerdo_por_nino As Double
    Dim precio_de_recuerdo_por_nina As Double
    Dim precio_de_recuerdo_por_adulto As Double

    'Variables de salón
    Dim precio_de_salon As Double
    Dim salon_elegido As String

    'variables de cantidad de pesonas
    Dim cantidad_de_adultos As Integer
    Dim total_de_personas As Integer

    'Duración de la fiesta
    Dim duracion_total_de_la_fiesta As Double

    'Variable de decoración
    Dim precio_por_decoracion As Double

    'Variable de Música
    Dim precio_por_musica As Double

    'Variable de recreación
    Dim precio_por_recreacion As Double

    'Variables de meseros
    Dim cantidad_de_meseros_cada_30 As Integer
    Dim cantidad_de_meseros_cada_100 As Integer

    'Habilita o desabilita los controles para agregar o quitar choferes de la cotización
    Private Sub CheckBoxChoferesDesignados_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxChoferesDesignados.CheckedChanged
        'Creamos un objeto checkBox de Tipo ChecBox que contendrá todas las propiedades el objeto que ejecutó este evento
        Dim checkBox As CheckBox = DirectCast(sender, CheckBox)
        LabelCantidadDeChoferes.Enabled = checkBox.Checked
        NumericUpDownCantidadDeChoferes.Enabled = checkBox.Checked
    End Sub
    'Habilita o desabilita si se quiere incluir recordatorios para los invitados
    Private Sub CheckBoxRecordatoriosParaInvitados_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxRecordatoriosParaInvitados.CheckedChanged
        'Creamos un objeto checkBox de Tipo ChecBox que contendrá todas las propiedades el objeto que ejecutó este evento
        Dim checkBox As CheckBox = DirectCast(sender, CheckBox)
        'Habilita el control para indicar si se quiere incluir bevidas en los recordatorios
        CheckBoxIncluirBebidaEnRecordatorio.Enabled = checkBox.Checked
    End Sub
    'Habilita o desabilita los si se quiere incluir Espectáculos a la cotización
    Private Sub CheckBoxEspectaculoArtistico_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxEspectaculoArtistico.CheckedChanged
        'Creamos un objeto checkBox de Tipo ChecBox que contendrá todas las propiedades el objeto que ejecutó este evento
        Dim checkBox As CheckBox = DirectCast(sender, CheckBox)
        'Habilita todos los controles para elegir los espectáculos que por defecto están deabilitados
        GroupBoxEspectaculos.Enabled = checkBox.Checked
    End Sub
    'Se configura el salón y se estipula el mínimo de duración de fiesta
    Private Sub RadioButtonSalonA_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonSalonA.CheckedChanged
        'Creamos un objeto checkBox de Tipo ChecBox que contendrá todas las propiedades el objeto que ejecutó este evento
        Dim radioButtons As RadioButton = DirectCast(sender, RadioButton)
        'Se configura un valor mínimo de tiempo de fiesta tanto para niños y adultos
        'En este caso la duracion de la fiesta no puede ser menos a 5 horas por lo que configuramos un mínimo de duración de 2.5 horas para cada uno
        NumericUpDownDuracionNinos.Minimum = 2.5
        NumericUpDownDuracionAdultos.Minimum = 2.5
        NumericUpDownDuracionMusica.Minimum = 3

        'Definimos el valor
        NumericUpDownDuracionNinos.Value = 2.5
        NumericUpDownDuracionAdultos.Value = 2.5
        NumericUpDownDuracionMusica.Value = 3
    End Sub

    Private Sub RadioButtonSalonB_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonSalonB.CheckedChanged
        'Creamos un objeto checkBox de Tipo ChecBox que contendrá todas las propiedades el objeto que ejecutó este evento
        Dim radioButtons As RadioButton = DirectCast(sender, RadioButton)
        'Se configura un valor mínimo de tiempo de fiesta tanto para niños y adultos
        'En este caso la duracion de la fiesta no puede ser menos a 3 horas por lo que configuramos un mínimo de duración de 1.5 horas para cada uno
        NumericUpDownDuracionNinos.Minimum = 1.5
        NumericUpDownDuracionAdultos.Minimum = 1.5
        NumericUpDownDuracionMusica.Minimum = 4

        'Definimos el valor
        NumericUpDownDuracionNinos.Value = 1.5
        NumericUpDownDuracionAdultos.Value = 1.5
        NumericUpDownDuracionMusica.Value = 4
    End Sub

    Private Sub RadioButtonSalonC_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonSalonC.CheckedChanged
        'Creamos un objeto checkBox de Tipo ChecBox que contendrá todas las propiedades el objeto que ejecutó este evento
        Dim radioButtons As RadioButton = DirectCast(sender, RadioButton)
        'Se configura un valor mínimo de tiempo de fiesta tanto para niños y adultos
        'En este caso como desabilitamos los controles de duración establecemos su valor mínimo en 0
        NumericUpDownDuracionNinos.Minimum = 1
        NumericUpDownDuracionAdultos.Minimum = 1
        NumericUpDownDuracionMusica.Minimum = 1
        'Definimos el valor
        NumericUpDownDuracionNinos.Value = 1
        NumericUpDownDuracionAdultos.Value = 1
        NumericUpDownDuracionMusica.Value = 1
    End Sub
    'Control que contiene la cantidad de niños la cual asigna si los recuerdos deben ser una piñatica o una piñata
    Private Sub NumericUpDownCantidadDeNinos_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDownCantidadDeNinos.ValueChanged, NumericUpDownCantidadDeNinas.ValueChanged
        'Nos interesa comprobar si la cantidad ingresada supera los 100 niños
        'Para eso hacemos uso de un if en donde preguntamos si la cantidad de niños es mayor a 100
        If NumericUpDownCantidadDeNinos.Value + NumericUpDownCantidadDeNinas.Value >= 100 Then
            'Si ocurre que es mayor a 100 entoces asignamos un valor de true a la variable tipo_de_recuerdo (recordemos que el valor true representa una piñata y false una piñatica)
            tipo_de_recuerdo = True
        Else
            'En caso de que la cantidad de niños sea menor a 100 el ttipo_de_recuerdo debe tener un valor de false
            tipo_de_recuerdo = False
        End If

        cantidad_de_meseros_cada_30 = ((NumericUpDownCantidadDeNinos.Value + NumericUpDownCantidadDeNinas.Value) * 3) / 30
        cantidad_de_meseros_cada_100 = (((NumericUpDownCantidadDeNinos.Value + NumericUpDownCantidadDeNinas.Value) * 3) / 50)
        NumericUpDownCantidadDeMeseros.Value = cantidad_de_meseros_cada_30 + cantidad_de_meseros_cada_100

        'El valor de tipo_de_recuerdo anida los controles dentro de los Espectáculos por lo cuál lo podemos utilizar de la siguiente manera
        'Abilitamos o desabilitamos los grupos en función de su valor
        GroupBoxEspectaculoDePinata.Enabled = tipo_de_recuerdo
        GroupBoxEspectaculoDePinatica.Enabled = Not tipo_de_recuerdo
    End Sub
    Private Sub CheckBoxMusicaParaReunion_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxMusicaParaReunion.CheckedChanged
        'Creamos un objeto checkBox de Tipo ChecBox que contendrá todas las propiedades el objeto que ejecutó este evento
        Dim checkBox As CheckBox = DirectCast(sender, CheckBox)
        LabelCantidadDeHorasParaLaMusica.Enabled = checkBox.Checked
        NumericUpDownDuracionMusica.Enabled = checkBox.Checked
    End Sub
    'Se genera la cotización al presionar el botón confirmar
    Private Sub ButtonConfirmar_Click(sender As Object, e As EventArgs) Handles ButtonConfirmar.Click
        DataGridViewTotal.Rows.Clear()
        total_A_Pagar = 0
        'Creamos una variable Double que contendrá el total de la cotización
        DefinirTipoDeMoneda()
        CalcularTotalDePersonas()
        CalcularPrecioPorTipoDeComida()
        CalcularPrecioDeRecordatorio()
        CalcularDuracionDeLaFiesta()
        CalcularPrecioDelLugarDeRecepcion()
        CalcularPrecioPorDecoracion()
        CalcularPrecioDeMusica()
        CalcularPrecioPorRecreacion()
        CalcularPrecioPorMeseros()
        CalcularPrecioDeEspectaculos()
        CalcularPrecioDeInvitaciones()
        CalcularPrecioDeDivulgacion()
        CalcularPrecioDeConductor()
        CalcularTotalSegunFormaDePago()
        ImprimirTotal()

    End Sub
    'Método qeu añade los registros al datagrid
    Sub AnadirRegistro(ByVal nombre, ByVal precio)
        'Se crea una nueva fila en el datagrid y se guarda si índice en una variable rowIndex
        Dim rowIndex As Integer = DataGridViewTotal.Rows.Add()

        ' Agrega datos a las celdas de la nueva fila
        DataGridViewTotal.Rows(rowIndex).Cells("Nombre").Value = nombre
        DataGridViewTotal.Rows(rowIndex).Cells("Precio").Value = precio

        'Se suma el precio al total A pagar
        total_A_Pagar += precio
    End Sub
    'Método que define el tipo de moneda de forma global
    Sub DefinirTipoDeMoneda()
        'Se asigna true o false en función del radio button de pesos colombianos para realizar las operaciones pertinentes
        tipo_de_moneda = RadioButtonPesosColombianos.Checked
    End Sub

    'Método que calcula el total de personas que asistirán a la fiesta
    'Las especificaciones dicen que por cad niño asisten 2 padres
    Sub CalcularTotalDePersonas()
        'Por cada niño se debe agregar 2 padres que asisten a la fiesta y se considera en la variable cantidad_de_adultos
        cantidad_de_adultos = (NumericUpDownCantidadDeNinos.Value + NumericUpDownCantidadDeNinas.Value) * 2
        total_de_personas = (cantidad_de_adultos + NumericUpDownCantidadDeNinos.Value + NumericUpDownCantidadDeNinas.Value)
    End Sub
    'Método que calcula el precio de la comida en función de la opción elegida y la cantiad de personas
    Sub CalcularPrecioPorTipoDeComida()
        'Comprobamos si se eligió el tipo de comida
        If (RadioButtonBuffet.Checked Or RadioButtonPlatoEspecial.Checked Or RadioButtonPlatoEconomico.Checked Or RadioButtonComidaFormal.Checked Or RadioButtonTipicaColombiana.Checked) And (NumericUpDownCantidadDeNinas.Value + NumericUpDownCantidadDeNinos.Value) > 0 Then
            'Evaluamos los controles dentro del grupo tipo de comida y se retorna un valor en función del que está seleccionado
            If RadioButtonBuffet.Checked Then
                tipo_de_comida = "Buffet"
                precio_de_comida = If(tipo_de_moneda, 12500.0, 12500.0 / peso_vs_dolar)
            ElseIf RadioButtonPlatoEspecial.Checked Then
                tipo_de_comida = "Plato Especial"
                precio_de_comida = If(tipo_de_moneda, 10500.0, 10500.0 / peso_vs_dolar)
            ElseIf RadioButtonPlatoEconomico.Checked Then
                tipo_de_comida = "Plato Económico"
                precio_de_comida = If(tipo_de_moneda, 11000.0, 11000.0 / peso_vs_dolar)
            ElseIf RadioButtonComidaFormal.Checked Then
                tipo_de_comida = "Comida Formal"
                precio_de_comida = If(tipo_de_moneda, 5500.0, 5500.0 / peso_vs_dolar)
            ElseIf RadioButtonTipicaColombiana.Checked Then
                tipo_de_comida = "Típica Colombiana"
                precio_de_comida = If(tipo_de_moneda, 8950.0, 8950.0 / peso_vs_dolar)
            End If

            precio_total_de_comida = precio_de_comida * total_de_personas
            AnadirRegistro("Comida tipo " + tipo_de_comida + " para " + total_de_personas.ToString + " personas", precio_total_de_comida)
        End If
    End Sub
    'Método que añade un registro al final del datagrid, se llama cada vez que se quiere registrar algo
    Sub CalcularPrecioDeRecordatorio()
        'Para las Piñatas por cada niño se cobra $3.25/12,293.64, por cada niña $5.55/20,993.76 y por adulto $1.05/3,971.79
        'Para las Piñaticas por cada niño se cobra $5.5/20804.63, por cada niña $7.75/29315.61 y por adulto $1.95/7376.18
        'Preguntamos si se marcó el servicio adicional de recordatorios
        If CheckBoxRecordatoriosParaInvitados.Checked Then
            Dim refresco As Boolean = CheckBoxIncluirBebidaEnRecordatorio.Checked
            'Comprobamos el tipo de recuerdo
            If tipo_de_recuerdo Then
                precio_de_recuerdo_por_nino = If(tipo_de_moneda, 12293.64, 12293.64 / peso_vs_dolar)
                precio_de_recuerdo_por_nina = If(tipo_de_moneda, 20993.76, 20993.76 / peso_vs_dolar)
                precio_de_recuerdo_por_adulto = If(tipo_de_moneda, 3971.79, 3971.79 / peso_vs_dolar)
                'Añadimos el refresco o no
                If refresco Then
                    'En piñata,tienen un valor de $10.70/40474.46 por adulto y $5.40/20426.36 por niño o niña. E incluyen la cantidad que el invitado consuma.
                    precio_de_recuerdo_por_nina += If(tipo_de_moneda, 20426.36, 20426.36 / peso_vs_dolar)
                    precio_de_recuerdo_por_nino += If(tipo_de_moneda, 20426.36, 20426.36 / peso_vs_dolar)
                    precio_de_recuerdo_por_adulto += If(tipo_de_moneda, 40474.46, 40474.46 / peso_vs_dolar)
                End If
            Else
                precio_de_recuerdo_por_nino = If(tipo_de_moneda, 20804.63, 20804.63 / peso_vs_dolar)
                precio_de_recuerdo_por_nina = If(tipo_de_moneda, 29315.61, 29315.61 / peso_vs_dolar)
                precio_de_recuerdo_por_adulto = If(tipo_de_moneda, 7376.18, 7376.18 / peso_vs_dolar)
                'Añadimos el refresco o no
                If refresco Then
                    'Las bebidas en piñatica, tienen un valor de $12.50/47283.25 por adulto y $9.50/35935.27 por niño o niña.
                    precio_de_recuerdo_por_nina += If(tipo_de_moneda, 35935.27, 35935.27 / peso_vs_dolar)
                    precio_de_recuerdo_por_nino += If(tipo_de_moneda, 35935.27, 35935.27 / peso_vs_dolar)
                    precio_de_recuerdo_por_adulto += If(tipo_de_moneda, 47283.25, 47283.25 / peso_vs_dolar)
                End If
            End If

            Dim anadido As String = If(refresco, " con refresco", "")
            'Añadimos los 3 registros con los valores correspondientes de los precios de los recordatorios
            AnadirRegistro("Recordatorio para " + NumericUpDownCantidadDeNinas.Value.ToString + " niñas" + anadido, NumericUpDownCantidadDeNinas.Value * precio_de_recuerdo_por_nina)
            AnadirRegistro("Recordatorio para " + NumericUpDownCantidadDeNinos.Value.ToString + " niños" + anadido, NumericUpDownCantidadDeNinos.Value * precio_de_recuerdo_por_nino)
            AnadirRegistro("Recordatorio para " + cantidad_de_adultos.ToString + " adultos" + anadido, cantidad_de_adultos * precio_de_recuerdo_por_adulto)
        End If
    End Sub
    'Método que calcula la duración de la fiesta
    Sub CalcularDuracionDeLaFiesta()
        duracion_total_de_la_fiesta = NumericUpDownDuracionNinos.Value + NumericUpDownDuracionAdultos.Value
    End Sub
    'Método que calcula el precio del lugar en la que se realiza la fiesta
    Sub CalcularPrecioDelLugarDeRecepcion()
        'Sí se alquila un salón de Gran Categoría, se denomina “Tipo A”, y tiene un valor de $1500/5673990.00. por mínimo cinco horas. Y el valor de hora adicional es de $200.00/756532.00 
        'Sí se alquila un salón de Categoría Media se denomina “Tipo B”, y tiene un valor de $1000.0/3,782,660.00 por mínimo tres horas. Y el valor de hora adicional es de $125.00/472 832.5. 
        'Sí el homenajeado es quien presta su hogar, se denomina “Tipo C”, y no tiene valor de alquiler.
        If Not RadioButtonSalonC.Checked Then
            If RadioButtonSalonA.Checked Then
                precio_de_salon = If(tipo_de_moneda, 5673990.0, 5673990.0 / peso_vs_dolar)
                precio_de_salon += If(tipo_de_moneda, 756532.0 * duracion_total_de_la_fiesta, 756532.0 * duracion_total_de_la_fiesta / peso_vs_dolar)
                salon_elegido = "Salón A"
            ElseIf RadioButtonSalonB.Checked Then
                precio_de_salon = If(tipo_de_moneda, 3782660.0, 3782660.0 / peso_vs_dolar)
                precio_de_salon += If(tipo_de_moneda, 472832.5 * duracion_total_de_la_fiesta, 472832.5 * duracion_total_de_la_fiesta / peso_vs_dolar)
                salon_elegido = "Salón B"
            End If
            AnadirRegistro("Alquiler del " + salon_elegido + " por " + duracion_total_de_la_fiesta.ToString + " horas", precio_de_salon)
        Else
            salon_elegido = "Salón C"
        End If
    End Sub
    'Método que calcula el precio por decoración según el salón
    Sub CalcularPrecioPorDecoracion()
        'La decoración para salones tipo A es de $100.00/378266.0 Para tipo B es de $50.00/189133.0 y los de Tipo C es de $150.00/567399.0
        If CheckBoxDecoracionDeSalon.Checked Then
            If RadioButtonSalonA.Checked Then
                precio_por_decoracion = If(tipo_de_moneda, 378266.0, 378266.0 / peso_vs_dolar)
            ElseIf RadioButtonSalonB.Checked Then
                precio_por_decoracion = If(tipo_de_moneda, 189133.0, 189133.0 / peso_vs_dolar)
            ElseIf RadioButtonSalonC.Checked Then
                precio_por_decoracion = If(tipo_de_moneda, 567399.0, 567399.0 / peso_vs_dolar)
            End If

            AnadirRegistro("Decoración del " + salon_elegido, precio_por_decoracion)
        End If
    End Sub
    'Calcular precio del servicio de música
    Sub CalcularPrecioDeMusica()
        'Para Tipo A es de $250.000/945665.00  valor hora durante tres horas y por hora adicional es de $50.00/189133.0
        'Para Tipo B es de $350.000/1323931.0 por cuatro horas y la hora adicional es de $25.00/94566.5
        'Tipo C es de $100.000/378266.0 valor hora.
        If CheckBoxMusicaParaReunion.Checked Then
            If RadioButtonSalonA.Checked Then
                precio_por_musica = If(tipo_de_moneda, 945665.0, 945665.0 / peso_vs_dolar)
                precio_por_musica += If(tipo_de_moneda, 189133.0 * (NumericUpDownDuracionMusica.Value - 3), 189133.0 * (NumericUpDownDuracionMusica.Value - 3) / peso_vs_dolar)
            ElseIf RadioButtonSalonB.Checked Then
                precio_por_musica = If(tipo_de_moneda, 1323931.0, 1323931.0 / peso_vs_dolar)
                precio_por_musica += If(tipo_de_moneda, 94566.5 * (NumericUpDownDuracionMusica.Value - 4), 94566.5 * (NumericUpDownDuracionMusica.Value - 4) / peso_vs_dolar)
            ElseIf RadioButtonSalonC.Checked Then
                precio_por_musica = If(tipo_de_moneda, 378266.0 * NumericUpDownDuracionMusica.Value, 378266.0 * NumericUpDownDuracionMusica.Value / peso_vs_dolar)
            End If

            AnadirRegistro("Servicio de Música en " + salon_elegido + " por " + NumericUpDownDuracionMusica.Value.ToString + " horas", precio_por_musica)
        End If
    End Sub
    'Método que calcula el precio de recreación dirigida
    Sub CalcularPrecioPorRecreacion()
        'La recreación es dirigida. Para los niños se cobra $20.00/75653.2 por cada hora y para los adultos es de $15.00/56739.9 por hora.
        If CheckBoxRecreacionDirigidaParaNinosYAdultos.Checked Then
            precio_por_recreacion = If(tipo_de_moneda, (75653.2 + 56739.9) * duracion_total_de_la_fiesta, (75653.2 + 56739.9) * duracion_total_de_la_fiesta / peso_vs_dolar)
            AnadirRegistro("Recreación dirigida para niños y adultos por " + duracion_total_de_la_fiesta.ToString + " horas", precio_por_recreacion)
        End If
    End Sub
    'Método que calcula el precio en función de la cantidad de meseros
    Sub CalcularPrecioPorMeseros()
        'El servicio de meseros tiene la siguiente característica: son 3 meseros por cada 30 personas y el valor de la hora por mesero es de $25.00 / 94566.5. 
        'Pero por cada 100 personas hay dos meseros adicionales que cobran $10.00/37826.6 hora.
        If CheckBoxServicioDeMesero.Checked Then
            Dim precio As Double = 0
            Dim meseros As Integer = cantidad_de_meseros_cada_30 + cantidad_de_meseros_cada_100
            precio = If(tipo_de_moneda, 94566.5 * cantidad_de_meseros_cada_30 * duracion_total_de_la_fiesta, 94566.5 * cantidad_de_meseros_cada_30 * duracion_total_de_la_fiesta / peso_vs_dolar)
            precio += If(tipo_de_moneda, 37826.6 * cantidad_de_meseros_cada_100 * duracion_total_de_la_fiesta, 37826.6 * cantidad_de_meseros_cada_100 * duracion_total_de_la_fiesta / peso_vs_dolar)

            AnadirRegistro("Servicio de " + meseros.ToString + " meseros", precio)
        End If
    End Sub
    'Método que calcula el precio de los espectáculos según los seleccionados
    Sub CalcularPrecioDeEspectaculos()
        'Piñatas
        'i.Musical infantil Allegro ma non troppo:  $500.00 / 1891330.0
        'ii.Musical infantil Allegro molto:   $1000.00 / 3782660.0
        'iii.Musical infantil Allegro assai:   $1500.00 / 5673990.0
        'b.Piñaticas
        'i.Musical infantil Andante:   $100.00 / 378266.0
        'ii.Musical infantil Adagio:   $250.00 / 945665.0
        'iii.Musical adulto Vivace:   $400.00 / 1513064.0
        'iv.Musical adulto Presto:   $500.00 / 1891330.0

        'Comprobamos si el check box de espectáculos está seleccionado
        If CheckBoxEspectaculoArtistico.Checked Then
            If tipo_de_recuerdo Then
                If CheckBoxAllegroManNonTroppo.Checked Then
                    AnadirRegistro("Espectáculo Allegro ManNonTroppo", If(tipo_de_moneda, 1891330.0, 1891330.0 / peso_vs_dolar))
                End If
                If CheckBoxAllegroMolto.Checked Then
                    AnadirRegistro("Espectáculo Allegro Molto", If(tipo_de_moneda, 3782660.0, 3782660.0 / peso_vs_dolar))
                End If
                If CheckBoxAllegroAsiai.Checked Then
                    AnadirRegistro("Espectáculo Allegro Asiai", If(tipo_de_moneda, 5673990.0, 5673990.0 / peso_vs_dolar))
                End If
            Else
                If CheckBoxMusicaInfantilAndante.Checked Then
                    AnadirRegistro("Espectáculo Infantil Andante", If(tipo_de_moneda, 378266.0, 378266.0 / peso_vs_dolar))
                End If
                If CheckBoxMusicaInfantilAdagio.Checked Then
                    AnadirRegistro("Espectáculo Infantil Adagio", If(tipo_de_moneda, 945665.0, 945665.0 / peso_vs_dolar))
                End If
                If CheckBoxMusicaAdultoVivace.Checked Then
                    AnadirRegistro("Espectáculo Adulto Vivace", If(tipo_de_moneda, 1513064.0, 1513064.0 / peso_vs_dolar))
                End If
                If CheckBoxMusicaAdultoPresto.Checked Then
                    AnadirRegistro("Espectáculo Adulto Presto", If(tipo_de_moneda, 1891330.0, 1891330.0 / peso_vs_dolar))
                End If
            End If
        End If
    End Sub
    'Método que calcula el precio de las invitaciones
    Sub CalcularPrecioDeInvitaciones()
        'La impresión de las invitaciones, también es opcional. En caso de ser Piñata, se cobra $0.2 / 756.532  por niña(o) y para Piñatica, $0.26 / 1.000 por niña(o).
        'Comprobamos si el servicio de invitaciones está activo
        Dim cantidad As Integer = NumericUpDownCantidadDeNinas.Value + NumericUpDownCantidadDeNinos.Value
        If CheckBoxImpresionDeInvitaciones.Checked Then
            If tipo_de_recuerdo Then
                AnadirRegistro("Impresión de invitaciones para " + cantidad.ToString + " niños", If(tipo_de_moneda, 756.532 * cantidad, 756.532 * cantidad / peso_vs_dolar))
            Else
                AnadirRegistro("Impresión de invitaciones para " + cantidad.ToString + " niños", If(tipo_de_moneda, 1000 * cantidad, 1000 * cantidad / peso_vs_dolar))
            End If
        End If
    End Sub
    'Método que calcula el precio de divulgación de la fiesta
    Sub CalcularPrecioDeDivulgacion()
        'Se puede contratar en forma opcional también, la divulgación en prensa de la reunión.
        'Fotos y vídeos entre otros, por valor de $1500.00 / 5673990.0 en piñata o $550.00 / 2080463.0 en piñatica.
        If CheckBoxDivulgacionDeFiesta.Checked Then
            If tipo_de_recuerdo Then
                AnadirRegistro("Divulgación de fiesta", If(tipo_de_moneda, 5673990.0, 5673990.0 / peso_vs_dolar))
            Else
                AnadirRegistro("Divulgación de fiesta", If(tipo_de_moneda, 2080463.0, 2080463.0 / peso_vs_dolar))
            End If
        End If
    End Sub
    'Método que calcula el costo por contrato de conductoes
    Sub CalcularPrecioDeConductor()
        'Como última opción, el contratante puede solicitar o no el servicio de “Conductor Elegido” para sus invitados.
        'De ser así, se puede seleccionar la cantidad de conductores, donde cada servicio tiene un costo de $20.00 / 75653.2
        'Se comprueba si el check box del servicio de conductoes está activo
        If CheckBoxChoferesDesignados.Checked Then
            Dim precio As Double = NumericUpDownCantidadDeChoferes.Value * If(tipo_de_moneda, 75653.2, 75653.2 / peso_vs_dolar)
            AnadirRegistro("Contrato de " + NumericUpDownCantidadDeChoferes.Value.ToString + " choferes", precio)
        End If
    End Sub
    'Método que calcula el total según el tipo de pago
    Sub CalcularTotalSegunFormaDePago()
        'a.	Tarjeta débito: al valor obtenido, se le aumenta el 7,5%.
        'b.Tarjeta crédito: al valor obtenido, se le aumenta el 12, 5%.
        'c.Cheque al día: al valor obtenido, se le aumenta el 5%.
        'd.Cheque post - fechado: al valor obtenido, se le aumenta el 15, 25%.
        'e.Bono corporativo: al valor obtenido, se le descuenta el 10%.
        'f.Efectivo : no sufre variación.cO TOTAL

        If Not RadioButtonEfectivo.Checked Then
            If RadioButtonTarjetaDebito.Checked Then
                AnadirRegistro("Recargo por pago con tarjeta de Débito", total_A_Pagar * 0.075)
            End If
            If RadioButtonTarjetaCredito.Checked Then
                AnadirRegistro("Recargo por pago con tarjeta de Crédito", total_A_Pagar * 0.125)
            End If
            If RadioButtonChequeAlDia.Checked Then
                AnadirRegistro("Recargo por pago con cheque al día", total_A_Pagar * 0.05)
            End If
            If RadioButtonChequePostFecha.Checked Then
                AnadirRegistro("Recargo por pago con cheque post fecha", total_A_Pagar * 0.15)
            End If
            If RadioButtonBonoCorporativo.Checked Then
                AnadirRegistro("Recargo por pago con bono corporativo", total_A_Pagar * 0.1)
            End If
        End If

    End Sub
    'Método que imprime el total
    Sub ImprimirTotal()
        AnadirRegistro("Total", total_A_Pagar)
    End Sub
End Class
