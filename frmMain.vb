Imports System.Threading

Public Class frmMain

   Private mblnExitThread As Boolean = False
   Private mstrFileContents As String
   Private mintReadPosition As Integer
   Private mobjRandom As Random
   Private Const mintStep As Integer = 20000
   Private mstrAnswer As String = ""
   Delegate Sub objCallBack(ByVal pstrText As String)
   Private intSleepCounter As Integer = 0

   Private Sub mnuTimer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTimer.Click

      btnMode.Image = mnuTimer.Image
      btnMode.Text = mnuTimer.Text

   End Sub

   Private Sub mnuManual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuManual.Click

      btnMode.Image = mnuManual.Image
      btnMode.Text = mnuManual.Text

   End Sub

   Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

      Dim objThread As Thread

      mstrFileContents = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath + "\questions.txt")
      mobjRandom = New Random()
      mintReadPosition = mobjRandom.NextDouble * mstrFileContents.Length
      mintReadPosition = Strings.InStr(mintReadPosition, mstrFileContents, vbCrLf)
      If mintReadPosition > 0 Then
         mintReadPosition += 2  ' move after the carriage return line feed
      End If
      DisplayTrivia()

      txtDisplay.SelectionStart = 0
      txtDisplay.SelectionLength = 0

      objThread = New Thread(AddressOf StartThread)
      objThread.Start()


   End Sub

   Private Sub StartThread()

      Try
         Do While Not mblnExitThread
            If btnMode.Text = mnuTimer.Text Then
               TimerDisplayTrivia()
            End If
         Loop

      Catch ex As Exception
         MessageBox.Show(ex.Message, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Application.Exit()

      End Try

   End Sub

   Private Sub frmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

      mblnExitThread = True

   End Sub


   Private Sub DisplayTrivia()

      Dim intEndPosition As Integer
      Dim strQuestion As String

      If mstrAnswer <> "" Then
         txtDisplay.Text = mstrAnswer
         mstrAnswer = ""
      Else
         intEndPosition = Strings.InStr(mintReadPosition, mstrFileContents, vbCrLf)
         strQuestion = Strings.Mid(mstrFileContents, mintReadPosition, intEndPosition - mintReadPosition)
         intEndPosition = Strings.InStr(strQuestion, "*")
         mstrAnswer = Strings.Mid(strQuestion, intEndPosition + 1, strQuestion.Length - intEndPosition)
         strQuestion = Strings.Left(strQuestion, intEndPosition - 1)
         txtDisplay.Text = strQuestion
      End If

   End Sub

   Private Sub frmMain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

      Select Case e.KeyCode
         Case Keys.Return
            If mstrAnswer <> "" Then
               DisplayTrivia()
            Else
               mintReadPosition += mintStep - (mobjRandom.NextDouble * mintStep * 2)
               If mintReadPosition < 0 Then
                  mintReadPosition += mstrFileContents.Length
               End If
               If mintReadPosition > mstrFileContents.Length Then
                  mintReadPosition -= mstrFileContents.Length
               End If
               mintReadPosition = Strings.InStr(mintReadPosition, mstrFileContents, vbCrLf)
               If mintReadPosition > 0 Then
                  mintReadPosition += 2  ' move after the carriage return line feed
               End If

               DisplayTrivia()
            End If

            intSleepCounter = 0

         Case Keys.Right
            If mstrAnswer <> "" Then
               DisplayTrivia()
            Else
               mintReadPosition = Strings.InStr(mintReadPosition, mstrFileContents, vbCrLf)
               If mintReadPosition > 0 Then
                  mintReadPosition += 2  ' move after the carriage return line feed
               End If

               DisplayTrivia()
            End If

            intSleepCounter = 0

         Case Keys.Escape
            Application.Exit()

      End Select

   End Sub

   Private Sub TimerDisplayTrivia()

      Thread.Sleep(1000)
      intSleepCounter += 1
      If intSleepCounter >= 5 Then
         intSleepCounter = 0

         If mstrAnswer <> "" Then
            DisplayTriviaFromTimer()
         Else
            mintReadPosition += mintStep - (mobjRandom.NextDouble * mintStep * 2)
            If mintReadPosition < 0 Then
               mintReadPosition += mstrFileContents.Length
            End If
            If mintReadPosition > mstrFileContents.Length Then
               mintReadPosition -= mstrFileContents.Length
            End If
            mintReadPosition = Strings.InStr(mintReadPosition, mstrFileContents, vbCrLf)
            If mintReadPosition > 0 Then
               mintReadPosition += 2  ' move after the carriage return line feed
            End If

            DisplayTriviaFromTimer()
         End If

      End If

   End Sub

   Private Sub DisplayTriviaFromTimer()

      Dim intEndPosition As Integer
      Dim strQuestion As String

      If mstrAnswer <> "" Then
         DisplayTextFromThread(mstrAnswer)
         mstrAnswer = ""
      Else
         intEndPosition = Strings.InStr(mintReadPosition, mstrFileContents, vbCrLf)
         strQuestion = Strings.Mid(mstrFileContents, mintReadPosition, intEndPosition - mintReadPosition)
         intEndPosition = Strings.InStr(strQuestion, "*")
         mstrAnswer = Strings.Mid(strQuestion, intEndPosition + 1, strQuestion.Length - intEndPosition)
         strQuestion = Strings.Left(strQuestion, intEndPosition - 1)
         DisplayTextFromThread(strQuestion)
      End If

   End Sub

   Private Sub DisplayTextFromThread(ByVal pstrText As String)

      Try
         If txtDisplay.InvokeRequired Then
            Dim objDelegate As New objCallBack(AddressOf DisplayTextFromThread)
            Invoke(objDelegate, New Object() {pstrText})
         Else
            txtDisplay.Text = pstrText
         End If

      Catch ex As Exception
         ' do nothing
      End Try

   End Sub

   
End Class

