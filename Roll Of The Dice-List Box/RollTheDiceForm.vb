'Calvin Coxen
'RCET0265
'Fall 2020
'Roll Of The Dice-List Box
'https://github.com/CalvinAC/Roll-Of-The-Dice-List-Box

Option Strict On
Option Explicit On

Public Class RollTheDiceForm


    Sub RollDie()

        Dim dieRoll As Integer
        Dim rolls(12) As Integer
        Dim row As Integer
        Dim text1 As String
        Dim text2 As String
        Dim dashLines As String
        Dim listBoxTitle As String

        'Rolls the dice 1000 times
        For i = 1 To 1000
            dieRoll = GetRandomNumber(1, 11)
            rolls(dieRoll) += 1
        Next

        'Creates place holder for data from the die rolls
        For i = 2 To 12
            text1 = (text1 & String.Format("{0,11}", i & "|"))
        Next

        For i = 0 To 10
            text2 = (text2 & String.Format("{0,10}", rolls(i) & "|"))
        Next

        dashLines = (StrDup(144, "-"))

        'Prints the text into the list box
        RollDiceListBox.Items.Add("Roll The Dice")
        RollDiceListBox.Items.Add(dashLines)
        RollDiceListBox.Items.Add(text1)
        RollDiceListBox.Items.Add(dashLines)
        RollDiceListBox.Items.Add(text2)
        RollDiceListBox.Items.Add(dashLines)

        Erase rolls
        ReDim rolls(12)

    End Sub

    'Randomizes the numbers between 1 to 12
    Function GetRandomNumber(ByVal min As Integer, ByVal max As Integer) As Integer
        Dim number As Single
        Randomize()
        number = CInt(Int(12 * Rnd()) + 1)
        number = ((max - min + 1) * Rnd()) + min
        Return CInt((number))

    End Function
    Private Sub RollButton_Click(sender As Object, e As EventArgs) Handles RollButton.Click
        RollDie()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        RollDiceListBox.Items.Add("Clear the dice rolls by selecting the Clear button, or by pressing the C key")

    End Sub
    Private Sub RollTheDiceForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Yeet Le Dice"
    End Sub
    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        RollDiceListBox.Items.Clear()
    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        RollDiceListBox.Items.Add("Roll the dice by selecting the Roll button, or by pressing the R key")
    End Sub
End Class
