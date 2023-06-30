Public Class Form1

    'Habilita o desabilita los controles para agregar o quitar meseros de la cotización
    Private Sub CheckBoxServicioDeMesero_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxServicioDeMesero.CheckedChanged
        'Creamos un objeto checkBox de Tipo ChecBox que contendrá todas las propiedades el objeto que ejecutó este evento
        'En este caso es el CheckBoxServicioDeMesero
        Dim checkBox As CheckBox = DirectCast(sender, CheckBox)
        LabelCantidadDeMeseros.Enabled = checkBox.Checked
        NumericUpDownCantidadDeMeseros.Enabled = checkBox.Checked
    End Sub

    'Habilita o desabilita los controles para agregar o quitar choferes de la cotización
    Private Sub CheckBoxChoferesDesignados_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxChoferesDesignados.CheckedChanged
        'Creamos un objeto checkBox de Tipo ChecBox que contendrá todas las propiedades el objeto que ejecutó este evento
        'En este caso es el CheckBoxChoferesDesignados
        Dim checkBox As CheckBox = DirectCast(sender, CheckBox)
        LabelCantidadDeChoferes.Enabled = checkBox.Checked
        NumericUpDownCantidadDeChoferes.Enabled = checkBox.Checked
    End Sub

    Private Sub CheckBoxRecordatoriosParaInvitados_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxRecordatoriosParaInvitados.CheckedChanged
        'Creamos un objeto checkBox de Tipo ChecBox que contendrá todas las propiedades el objeto que ejecutó este evento
        'En este caso es el CheckBoxRecordatoriosParaInvitados
        Dim checkBox As CheckBox = DirectCast(sender, CheckBox)
        CheckBoxIncluirBebidaEnRecordatorio.Enabled = checkBox.Checked
    End Sub

    Private Sub CheckBoxEspectaculoArtistico_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxEspectaculoArtistico.CheckedChanged
        'Creamos un objeto checkBox de Tipo ChecBox que contendrá todas las propiedades el objeto que ejecutó este evento
        'En este caso es el CheckBoxRecordatoriosParaInvitados
        Dim checkBox As CheckBox = DirectCast(sender, CheckBox)
        GroupBoxEspectaculos.Enabled = checkBox.Checked
    End Sub

    Private Sub RadioButtonSalonA_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonSalonA.CheckedChanged
        Dim radioButtons As RadioButton = DirectCast(sender, RadioButton)
        NumericUpDownDuracionNinos.Minimum = 2.5
        NumericUpDownDuracionAdultos.Minimum = 2.5
    End Sub

    Private Sub RadioButtonSalonB_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonSalonB.CheckedChanged
        Dim radioButtons As RadioButton = DirectCast(sender, RadioButton)
        NumericUpDownDuracionNinos.Minimum = 1.5
        NumericUpDownDuracionAdultos.Minimum = 1.5
    End Sub

    Private Sub RadioButtonSalonC_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonSalonC.CheckedChanged
        Dim radioButtons As RadioButton = DirectCast(sender, RadioButton)
        GroupBoxDuracionDeFiesta.Enabled = Not radioButtons.Checked
    End Sub
End Class
