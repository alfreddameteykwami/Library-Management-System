Imports MySql.Data.MySqlClient

Public Module UserSession
    Public LoggedInRole As String = ""          'Stores "Admin" or "User"
    Public LoggedInMemberID As String = ""      'Stores member_id 
    Public loggedInUsername As String = ""
End Module
