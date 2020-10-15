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
        Dim rolls(10) As Integer
        Dim text1 As String
        Dim text2 As String
        Dim dashLines As String
        Randomize()

        'Rolls the dice 1000 times
        For i = 1 To 1000
            dieRoll = CInt(GetRandomNumber(1, 6))
            rolls(dieRoll - 2) += 1
        Next

        'Creates place holder for data from the die rolls
        For i = 2 To 12
            text1 = text1 & String.Format("{0,11}", i & "|")
        Next

        For i = 0 To 10
            text2 = text2 & String.Format("{0,10}", rolls(i) & "|")
        Next

        dashLines = (StrDup(144, "-"))

        'Prints the text into the list box
        RollDiceListBox.Items.Add(vbTab & vbTab & vbTab & vbTab & "Roll The Dice")
        RollDiceListBox.Items.Add(dashLines)
        RollDiceListBox.Items.Add(text1)
        RollDiceListBox.Items.Add(dashLines)
        RollDiceListBox.Items.Add(text2)
        RollDiceListBox.Items.Add(dashLines)

        Erase rolls
        ReDim rolls(12)

    End Sub

    Function GetRandomNumber(ByVal min As Single, ByVal max As Single) As Single
        Dim roll1, roll2 As Double
        Dim sum As Integer
        'rolls 2 dice and add their values together
        Do
            roll1 = (max * Rnd()) + 0.5
            roll2 = (max * Rnd()) + 0.5
        Loop While roll1 < min - 0.5 Or roll1 >= max + 0.5 Or
            roll2 < min - 0.5 Or roll2 >= max + 0.5


        sum = CInt(roll1) + CInt(roll2)
        Return sum

    End Function
    Private Sub RollButton_Click(sender As Object, e As EventArgs) Handles RollButton.Click
        RollDie()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        RollDiceListBox.Items.Clear()
    End Sub
    Private Sub RollTheDiceForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Yeet Le Dice"
    End Sub
    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        RollDiceListBox.Items.Clear()
    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        RollDie()
    End Sub

    Private Sub MenuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuToolStripMenuItem.Click
        RollDiceListBox.Items.Clear()
    End Sub

    Private Sub HelpToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem1.Click
        RollDiceListBox.Items.Add("Clear the dice rolls by selecting the Clear button, or by pressing the C key")
        RollDiceListBox.Items.Add("Roll the dice by selecting the Roll button, or by pressing the R key")
    End Sub
End Class
