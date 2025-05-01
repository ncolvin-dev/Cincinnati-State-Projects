Public Class Form1
    Dim dblMonthlyRainfall(11) As Double
    Dim strMonths() As String = {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"}
    Dim strSeasons() As String = {"Winter", "Spring", "Summer", "Fall"}
    Dim dblSeasonsTotals(3) As Double
    Dim strMostRainSeason As String
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim intIndex As Short
        Dim strRainfall As String
        Dim strCurrentMonth As String
        Dim blnFlag As Boolean

        lstResult.Items.Add("Yearly Rainfall")
        lstResult.Items.Add("===============")
        lstResult.Items.Add("")

        For intIndex = 0 To dblMonthlyRainfall.Length - 1
            strCurrentMonth = strMonths(intIndex)
            blnFlag = False
            Do Until blnFlag = True
                strRainfall = InputBox("Please enter the total monthly rainfall for " & strCurrentMonth)
                If Double.TryParse(strRainfall, dblMonthlyRainfall(intIndex)) Then
                    lstResult.Items.Add("Total monthly rainfall for " & strCurrentMonth & " is " & strRainfall & " inches")
                    blnFlag = True
                Else
                    MessageBox.Show("Please enter a number")
                End If
            Loop

        Next

        btnSubmit.Enabled = False
    End Sub
    Private Sub btnDisplay_Click(sender As Object, e As EventArgs) Handles btnDisplay.Click
        Dim intIndex As Integer
        Dim dblYearlyRainfall As Double
        Dim dblMostRain As Double
        Dim dblLeastRain As Double
        Dim dblAvarageRain As Double
        Dim strMostRainMonth As String
        Dim strLeastRainMonth As String
        Dim dblMostRainSeason As Double

        dblYearlyRainfall = Get_Total_Rainfall(intIndex)
        dblMostRain = Get_Most_Rainfall(intIndex)
        strMostRainMonth = Get_Most_Rainfall_Month(intIndex)
        dblLeastRain = Get_Least_Rainfall(intIndex)
        strLeastRainMonth = Get_Least_Rainfall_Month(intIndex)
        dblAvarageRain = Get_Avarage_Rainfall(dblYearlyRainfall)
        dblMostRainSeason = Get_Season_Totals(intIndex)

        Call Display_Statistics(dblYearlyRainfall, dblMostRain, strMostRainMonth, dblLeastRain, strLeastRainMonth, dblAvarageRain, dblMostRainSeason)
    End Sub

    Private Function Get_Total_Rainfall(ByVal intIndex As Integer)
        Dim dblTotal As Double
        For intIndex = 0 To dblMonthlyRainfall.Length - 1
            dblTotal += dblMonthlyRainfall(intIndex)
        Next
        Return dblTotal
    End Function

    Private Function Get_Most_Rainfall(ByVal intIndex As Integer)
        Dim dblMaxium As Double
        For intIndex = 0 To dblMonthlyRainfall.Length - 1
            If dblMonthlyRainfall(intIndex) > dblMaxium Then
                dblMaxium = dblMonthlyRainfall(intIndex)
            End If
        Next

        Return dblMaxium
    End Function

    Private Function Get_Most_Rainfall_Month(ByVal intIndex As Integer)
        Dim dblMaxium As Double
        Dim strHighestMonth As String
        For intIndex = 0 To dblMonthlyRainfall.Length - 1
            If dblMonthlyRainfall(intIndex) > dblMaxium Then
                dblMaxium = dblMonthlyRainfall(intIndex)
                strHighestMonth = strMonths(intIndex)
            End If
        Next
        Return strHighestMonth
    End Function

    Private Function Get_Least_Rainfall(ByVal intIndex As Integer)
        Dim dblMinium As Double
        dblMinium = dblMonthlyRainfall(0)
        For intIndex = 0 To dblMonthlyRainfall.Length - 1
            If dblMonthlyRainfall(intIndex) < dblMinium Then
                dblMinium = dblMonthlyRainfall(intIndex)
            End If
        Next

        Return dblMinium
    End Function

    Private Function Get_Least_Rainfall_Month(ByVal intIndex As Integer)
        Dim dblMinium As Double
        Dim strLeastMonth As String
        dblMinium = dblMonthlyRainfall(0)
        strLeastMonth = strMonths(intIndex)

        For intIndex = 0 To dblMonthlyRainfall.Length - 1
            If dblMonthlyRainfall(intIndex) < dblMinium Then
                dblMinium = dblMonthlyRainfall(intIndex)
                strLeastMonth = strMonths(intIndex)
            End If
        Next

        Return strLeastMonth
    End Function

    Private Function Get_Avarage_Rainfall(ByVal dblYearlyRainfall As Double)
        Dim dblAvarage As Double

        dblAvarage = dblYearlyRainfall / dblMonthlyRainfall.Length

        Return dblAvarage
    End Function
    Private Function Get_Season_Totals(ByVal intIndex As Integer)
        Dim dblHighestSeason As Double
        For intIndex = 0 To dblMonthlyRainfall.Length - 1
            Select Case intIndex
                Case 0, 1, 11
                    dblSeasonsTotals(0) += dblMonthlyRainfall(intIndex)
                Case 2, 3, 4
                    dblSeasonsTotals(1) += dblMonthlyRainfall(intIndex)
                Case 5, 6, 7
                    dblSeasonsTotals(2) += dblMonthlyRainfall(intIndex)
                Case 8, 9, 10
                    dblSeasonsTotals(3) += dblMonthlyRainfall(intIndex)
            End Select
        Next

        For intIndex = 0 To strSeasons.Length - 1
            If dblHighestSeason < dblSeasonsTotals(intIndex) Then
                dblHighestSeason = dblSeasonsTotals(intIndex)
                strMostRainSeason = strSeasons(intIndex)
            End If
        Next

        Return dblHighestSeason
    End Function

    Private Sub Display_Statistics(ByVal dblYearlyRainfall As Double, ByVal dblMostRain As Double, ByVal strMostRainMonth As String, ByVal dblLeastRain As Double, ByVal strLeastRainMonth As String, ByVal dblAvarageRain As Double, ByVal dblMostRainSeason As Double)
        lstDisplayTotals.Items.Add("Rainfall Statistics")
        lstDisplayTotals.Items.Add("===============")
        lstDisplayTotals.Items.Add("")
        lstDisplayTotals.Items.Add("Total Rainfall for year is " & dblYearlyRainfall & " inches")
        lstDisplayTotals.Items.Add("")
        lstDisplayTotals.Items.Add("Average Rainfall for year is " & dblAvarageRain.ToString("n2") & " inches")
        lstDisplayTotals.Items.Add("")
        lstDisplayTotals.Items.Add(strMostRainMonth & " had MOST rainfall with " & dblMostRain & " inches")
        lstDisplayTotals.Items.Add("")
        lstDisplayTotals.Items.Add(strLeastRainMonth & " had LEAST rainfall with " & dblLeastRain & " inches")
        lstDisplayTotals.Items.Add("")
        lstDisplayTotals.Items.Add(strMostRainSeason & " had MOST rainfall with " & dblMostRainSeason & " inches")

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

End Class
