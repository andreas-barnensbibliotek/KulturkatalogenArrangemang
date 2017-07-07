Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports KulturkatalogenArrangemang

<TestClass()> Public Class UnitTest1

    <TestMethod()> Public Sub TestMethod1()

        Dim testar As New kk_aj_arr_MainController
        Dim cmd As New commandTypeInfo

        cmd.CmdTyp = "bystatus"
        cmd.CmdtypUserid = 2
        cmd.cmdValue = "testarna"
        cmd.ArrStatusTyp = 4
        cmd.IsAdminRoll = 0
        cmd.CmdRoll1 = 6
        cmd.CmdRoll2 = 10


        Dim ret As arrangemangcontainerInfo = testar.getArrangemang(cmd)

        Dim x As arrangemangcontainerInfo = ret

    End Sub

    <TestMethod()> Public Sub updatetest()
        Dim cmdtyp As New updatearrcommand
        cmdtyp.Arrid = 1
        cmdtyp.ArrRollID = 1
        cmdtyp.arrUserid = 1
        cmdtyp.UpdValue = "ja"
        cmdtyp.CmdTyp = "pub" 'arrstat pub lookedat

        Dim testar As New kk_aj_arr_MainController

        Dim ret As arrangemangcontainerInfo = testar.updateArrPropeties(cmdtyp)

        Dim tmp As String = ret.Status

    End Sub
    <TestMethod()> Public Sub deleteArr()
        ' Behöver bara arrid för att tabort arrangemanget och content och arrtocontent
        Dim cmdtyp As New updatearrcommand
        cmdtyp.Arrid = 62
        Dim obj As New kk_aj_arr_MainController

        Dim rettyp As arrangemangcontainerInfo = obj.DelArrangemang(cmdtyp)

        Dim status = rettyp.Status



    End Sub


    <TestMethod()> Public Sub addtest()
        Dim cmdtyp As New updatearrcommand
        cmdtyp.Arrid = 0
        cmdtyp.ArrRollID = 0
        cmdtyp.arrUserid = 3
        cmdtyp.UpdValue = ""
        cmdtyp.CmdTyp = "add" 'arrstat pub lookedat


        Dim tmparr As New arrangemangInfo

        tmparr = insertfuntion(3)

        Dim testar As New kk_aj_arr_MainController

        Dim ret As arrangemangcontainerInfo = testar.addArrangemang(cmdtyp, tmparr)

        Dim tmp As String = ret.Status

    End Sub
    <TestMethod()> Public Sub getdetaljtest()

        Dim testar As New kk_aj_arr_MainController
        Dim cmd As New commandTypeInfo

        cmd.CmdTyp = "details"
        cmd.ArrID = 22
        cmd.CmdtypUserid = 2

        Dim ret As arrangemangcontainerInfo = testar.getArrangemang(cmd)

        Dim x As arrangemangcontainerInfo = ret

    End Sub
    Private Function insertfuntion(vald As Integer) As arrangemangInfo
        Dim tmparr As New arrangemangInfo

        tmparr.Arrangemangtyp = 2 'författarbesök
        tmparr.ArrangemangStatus = 1
        tmparr.Innehall = gettext(vald)
        tmparr.Konstform = 4 'dans
        'tmparr.MainImage = getimg(vald)
        'tmparr.MediaClip = getmovie(vald)
        tmparr.MediaList = getmedia()
        tmparr.Rubrik = "Konstrunda Ulricehamn"
        tmparr.UnderRubrik = "av ulricehamnare för ulricehamnare"
        tmparr.Utovare = 0 ' är denna större än 0 körs utövardata annar inte!
        tmparr.UtovareData = addutovare(vald)
        tmparr.Faktalist = faktalista(vald)
        tmparr.Datum = Date.Now


        Return tmparr
    End Function

    Private Function faktalista(vald As Integer) As List(Of faktainfo)

        Dim retlist As New List(Of faktainfo)

        Dim obj1 As New faktainfo

        Select Case vald
            Case 1
                obj1.FaktaTypID = 1
                obj1.FaktaValue = "Ja 50%"
                retlist.Add(obj1)
                obj1.FaktaTypID = 2
                obj1.FaktaValue = "200"
                retlist.Add(obj1)
                obj1.FaktaTypID = 3
                obj1.FaktaValue = "Nisse hult mfl"
                retlist.Add(obj1)
                obj1.FaktaTypID = 4
                obj1.FaktaValue = "majmånad"
                retlist.Add(obj1)

            Case 2
                obj1.FaktaTypID = 1
                obj1.FaktaValue = "Ja 100%"
                retlist.Add(obj1)
                obj1.FaktaTypID = 6
                obj1.FaktaValue = "200"
                retlist.Add(obj1)
                obj1.FaktaTypID = 17
                obj1.FaktaValue = "20 Ampere"
                retlist.Add(obj1)
                obj1.FaktaTypID = 38
                obj1.FaktaValue = "ja"
                retlist.Add(obj1)
            Case 3
                obj1.FaktaTypID = 1
                obj1.FaktaValue = "Ja 50%"
                retlist.Add(obj1)
                obj1.FaktaTypID = 6
                obj1.FaktaValue = "130"
                retlist.Add(obj1)
                obj1.FaktaTypID = 12
                obj1.FaktaValue = "5 m"
                retlist.Add(obj1)
                obj1.FaktaTypID = 14
                obj1.FaktaValue = "2.4 m"
                retlist.Add(obj1)
        End Select

        Return retlist

    End Function


    Private Function getmedia() As List(Of mediaInfo)
        Dim img As New mediaInfo
        Dim ret As New List(Of mediaInfo)

        img.MediaAlt = "finbild"
        img.MediaFilename = "bildnummer1.jpg"
        img.MediaFoto = "andreas Josefsson"
        img.MediaSize = "300kb"
        img.MediaUrl = "s-media-cache-ak0.pinimg.com/originals/a1/3d/7f/a13d7f89a80cad02f76830f87a7eaf52.jpg"
        img.MediaTyp = "3"
        ret.Add(img)
        Dim img2 As New mediaInfo
        img2.MediaAlt = "finbild med banan"
        img2.MediaFilename = "banan1.jpg"
        img2.MediaFoto = "andreas Josefsson"
        img2.MediaSize = "300kb"
        img2.MediaUrl = "p1.pichost.me/i/40/1636199.jpg"
        img2.MediaTyp = "2"
        ret.Add(img2)
        Dim img3 As New mediaInfo
        img3.MediaAlt = "finbild drak Ulla"
        img3.MediaFilename = "drakenummer1.jpg"
        img3.MediaFoto = "andreas Josefsson"
        img3.MediaSize = "300kb"
        img3.MediaUrl = "s-media-cache-ak0.pinimg.com/736x/9e/fd/27/9efd27afef4e8127923fbce92b8c967d.jpg"
        img3.MediaTyp = "2"
        ret.Add(img3)

        Return ret

    End Function
    Private Function getimg(v As Integer) As mediaInfo
        Dim img As New mediaInfo

        Select Case v
            Case 1
                img.MediaAlt = "finbild"
                img.MediaFilename = "bildnummer1.jpg"
                img.MediaFoto = "andreas Josefsson"
                img.MediaSize = "300kb"
                img.MediaUrl = "s-media-cache-ak0.pinimg.com/originals/a1/3d/7f/a13d7f89a80cad02f76830f87a7eaf52.jpg"
                img.MediaTyp = "1"
            Case 3
                img.MediaAlt = "finFILM Blade runner"
                img.MediaFilename = "FILMnummer1.jpg"
                img.MediaFoto = "andreas Josefsson"
                img.MediaSize = "300kb"
                img.MediaUrl = "youtu.be/gCcx85zbxz4"
                img.MediaTyp = "2"
            Case 2
                img.MediaAlt = "finFILM med Avengers"
                img.MediaFilename = "FILM1.jpg"
                img.MediaFoto = "andreas Josefsson"
                img.MediaSize = "300kb"
                img.MediaUrl = "youtu.be/GQ7kdlggtUU"
                img.MediaTyp = "2"

        End Select

        Return img

    End Function
    Private Function getmovie(v As Integer) As mediaInfo
        Dim img As New mediaInfo

        Select Case v
            Case 1
                img.MediaAlt = "finFILM Blade runner"
                img.MediaFilename = "FILMnummer1.jpg"
                img.MediaFoto = "andreas Josefsson"
                img.MediaSize = "300kb"
                img.MediaUrl = "youtu.be/gCcx85zbxz4"
                img.MediaTyp = "2"
            Case 2
                img.MediaAlt = "finFILM med Avengers"
                img.MediaFilename = "FILM1.jpg"
                img.MediaFoto = "andreas Josefsson"
                img.MediaSize = "300kb"
                img.MediaUrl = "youtu.be/GQ7kdlggtUU"
                img.MediaTyp = "2"
            Case 3
                img.MediaAlt = "finFILM WOT ulla"
                img.MediaFilename = "Wot.jpg"
                img.MediaFoto = "andreas Josefsson"
                img.MediaSize = "300kb"
                img.MediaUrl = "youtu.be/3SKj4V6hyd0"
                img.MediaTyp = "2"

        End Select

        Return img

    End Function
    Private Function gettext(val As Integer) As String

        Dim str As String = ""
        Select Case val
            Case 1
                str &= "Text nr 1 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. "
                str &= "Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc. Curabitur tortor. Pellentesque nibh. Aenean quam. In scelerisque sem at dolor. Maecenas mattis. Sed convallis tristique sem. Proin ut ligula vel nunc egestas porttitor. Morbi lectus risus, iaculis vel, suscipit quis, luctus non, massa. Fusce ac turpis quis ligula lacinia aliquet. Mauris ipsum. "
                str &= "Nulla metus metus, ullamcorper vel, tincidunt sed, euismod in, nibh. Quisque volutpat condimentum velit. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nam nec ante. Sed lacinia, urna non tincidunt mattis, tortor neque adipiscing diam, a cursus ipsum ante quis turpis. Nulla facilisi. Ut fringilla. Suspendisse potenti. Nunc feugiat mi a tellus consequat imperdiet. Vestibulum sapien. Proin quam. Etiam ultrices. Suspendisse in justo eu magna luctus suscipit. Sed lectus. "

            Case 2
                str &= "Text nr 2 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. "
                str &= "Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc. Curabitur tortor. Pellentesque nibh. Aenean quam. In scelerisque sem at dolor. Maecenas mattis. Sed convallis tristique sem. Proin ut ligula vel nunc egestas porttitor. Morbi lectus risus, iaculis vel, suscipit quis, luctus non, massa. Fusce ac turpis quis ligula lacinia aliquet. Mauris ipsum. "
                str &= "Nulla metus metus, ullamcorper vel, tincidunt sed, euismod in, nibh. Quisque volutpat condimentum velit. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nam nec ante. Sed lacinia, urna non tincidunt mattis, tortor neque adipiscing diam, a cursus ipsum ante quis turpis. Nulla facilisi. Ut fringilla. Suspendisse potenti. Nunc feugiat mi a tellus consequat imperdiet. Vestibulum sapien. Proin quam. Etiam ultrices. Suspendisse in justo eu magna luctus suscipit. Sed lectus. "
            Case 3
                str &= "Text nr 3 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. "
                str &= "Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc. Curabitur tortor. Pellentesque nibh. Aenean quam. In scelerisque sem at dolor. Maecenas mattis. Sed convallis tristique sem. Proin ut ligula vel nunc egestas porttitor. Morbi lectus risus, iaculis vel, suscipit quis, luctus non, massa. Fusce ac turpis quis ligula lacinia aliquet. Mauris ipsum. "
            Case 4
                str &= "Andreas har ändrat detta ordentligt!!!  "
                str &= "Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc. Curabitur tortor. Pellentesque nibh. Aenean quam. In scelerisque sem at dolor. Maecenas mattis. Sed convallis tristique sem. Proin ut ligula vel nunc egestas porttitor. Morbi lectus risus, iaculis vel, suscipit quis, luctus non, massa. Fusce ac turpis quis ligula lacinia aliquet. Mauris ipsum. "

        End Select
        Return str

    End Function

    Private Function addutovare(val As Integer) As utovareInfo
        Dim retobj As New utovareInfo
        Select Case val
            Case 1
                retobj.Adress = "grönahögsvägen 15"
                retobj.Efternamn = "Josefsson"
                retobj.Epost = "test@test.se"
                retobj.Fornamn = "B-G"
                retobj.Kommun = "Ulricehamn"
                retobj.Organisation = "biomatec"
                retobj.Ort = "Ulricehamn"
                retobj.Postnr = "52330"
                retobj.Telefon = "0321-15310"
                retobj.Weburl = "www.biomatec.se"
            Case 2
                retobj.Adress = "lindängsvägen 23"
                retobj.Efternamn = "Karlsson"
                retobj.Epost = "urk@test.se"
                retobj.Fornamn = "Svea"
                retobj.Kommun = "Ulricehamn"
                retobj.Organisation = "pro"
                retobj.Ort = "Ulricehamn"
                retobj.Postnr = "52343"
                retobj.Telefon = "0321-12310"
                retobj.Weburl = "www.pro.se"
            Case 3
                retobj.Adress = "jönköpingsvägen 15"
                retobj.Efternamn = "sandin"
                retobj.Epost = "sandin@test.se"
                retobj.Fornamn = "Gösta"
                retobj.Kommun = "Ulricehamn"
                retobj.Organisation = "UBAB"
                retobj.Ort = "Timmele"
                retobj.Postnr = "52350"
                retobj.Telefon = "0321-12310"
                retobj.Weburl = "www.ubab.se"

        End Select

        Return retobj

    End Function

    <TestMethod()> Public Sub Testarrbylatest()

        Dim testar As New kk_aj_arr_MainController
        Dim cmd As New commandTypeInfo

        cmd.CmdTyp = "bylatest"
        cmd.cmdValue = "top10"
        cmd.IsAdminRoll = 0
        cmd.CmdRoll1 = 6
        cmd.CmdRoll2 = 10


        Dim ret As arrangemangcontainerInfo = testar.getArrangemang(cmd)

        Dim x As arrangemangcontainerInfo = ret

    End Sub
    <TestMethod()> Public Sub TestEditArrangemangParametrar()

        Dim testar As New kk_aj_arr_MainController
        Dim cmd As New commandTypeInfo

        cmd.CmdTyp = "bylatest"
        cmd.cmdValue = "top10"
        cmd.IsAdminRoll = 0
        cmd.CmdRoll1 = 6
        cmd.CmdRoll2 = 10


        Dim ret As arrangemangcontainerInfo = testar.getArrangemang(cmd)

        Dim x As arrangemangcontainerInfo = ret

    End Sub
    <TestMethod()> Public Sub TestEditMedia()

        Dim testar As New kk_aj_arr_MainController
        Dim cmd As New commandTypeInfo

        Dim arrid As Integer = 28
        Dim medieid As Integer = 3

        Dim img2 As New mediaInfo
        img2.MediaID = medieid
        img2.MediaAlt = "finbild med banan"
        img2.MediaFilename = "till ARR 1 banan1.jpg"
        img2.MediaFoto = "andreas Josefsson"
        img2.MediaSize = "300kb"
        img2.MediaUrl = "http://p1.pichost.me/i/40/1636199.jpg"
        img2.MediaTyp = "2"
        img2.MediaVald = "nej"


        Dim ret As arrangemangcontainerInfo = testar.editMediaByMediaid(arrid, img2)
        Dim x As arrangemangcontainerInfo = ret
        If ret.Status = "updated" Then
            x.Status = "updated"
        End If
        If ret.Status = "error" Then
            x.Status = "error"
        End If


    End Sub
    <TestMethod()> Public Sub TestEditFakta()

        Dim testar As New kk_aj_arr_MainController
        Dim cmd As New commandTypeInfo

        Dim arrid As Integer = 28
        Dim Faktaid As Integer = 96

        Dim obj1 As New faktainfo
        obj1.Faktaid = Faktaid
        obj1.FaktaValue = "minst 100m brett!"

        Dim ret As arrangemangcontainerInfo = testar.editFaktaByFaktaid(arrid, obj1)
        Dim x As arrangemangcontainerInfo = ret
        If ret.Status = "updated" Then
            x.Status = "updated"
        End If
        If ret.Status = "error" Then
            x.Status = "error"
        End If


    End Sub

    <TestMethod()> Public Sub TestEditArrangemangDATA()

        Dim testar As New kk_aj_arr_MainController
        Dim cmd As New commandTypeInfo

        Dim tmpobj As New arrangemangInfo

        Dim arrid As Integer = 28
        Dim contentid As Integer = 21

        tmpobj.Arrid = arrid
        tmpobj.ContentID = contentid

        tmpobj.Konstform = 10
        tmpobj.Arrangemangtyp = 5
        tmpobj.Utovare = 4
        tmpobj.Publicerad = "ja"

        tmpobj.Rubrik = "Andreas ändrar igen"
        tmpobj.UnderRubrik = "ändringar fungerar!"
        tmpobj.Innehall = gettext(4)


        Dim ret As arrangemangcontainerInfo = testar.editArrangemang(tmpobj)
        Dim x As arrangemangcontainerInfo = ret
        If ret.Status = "updated" Then
            x.Status = "updated"
        End If
        If ret.Status = "error" Then
            x.Status = "error"
        End If


    End Sub
End Class