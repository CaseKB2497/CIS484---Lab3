<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Student_UI_Page.aspx.cs" Inherits="Student_UI_Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="Server">

    <h1 align="center">Add Student - Kris Case</h1>
    <div>
            <table>
                <tr>
                    <td>Connection Established?:</td>
                    <td>
                        <asp:TextBox ID="MessageTextBox" runat="server" Width="240px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Associated Prop:</td>
                    <td>
                        <asp:TextBox ID="studentAddress" runat="server" Width="240px"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table>
                <tr><td>&nbsp;&nbsp;</td></tr>
                <tr>
                    <td>First Name: </td>
                    <td>
                        <asp:TextBox id="firstName" runat="server"></asp:TextBox>
                    </td>
                    
                    <td>&nbsp; Last Name:</td>
                    <td>
                        <asp:TextBox ID="lastName" runat="server"></asp:TextBox>
                    </td>

                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Middle Name: </td>
                    <td>
                        <asp:TextBox ID="middleName" runat="server"></asp:TextBox>
                    </td>
                    <td>

                    &nbsp;&nbsp;
                        <asp:Button ID="SearchHouseNum" runat="server" Text="Search" OnClick="SearchHouseNum_Click" />

                    </td>
                </tr>
                <tr><td>
                        Date of Birth:
                    <br />
                    </td>
                    <td>
                        <asp:TextBox ID="dateOfBirth" runat="server" placeholder="mm/dd/yyyy"></asp:TextBox>
                    </td>
                </tr>
                <tr><td>&nbsp;&nbsp;</td></tr>
                <tr>
                    <td>House Number: </td>
                    <td>
                        <asp:TextBox ID="houseNumber" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;&nbsp;Street Address: </td>
                    <td>
                        <asp:TextBox ID="streetAddress" runat="server"></asp:TextBox>
                    </td>
                    
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; City: </td>
                    <td>
                        <asp:TextBox ID="cityCounty" runat="server"></asp:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td>State: </td>
                    <td>
                        <asp:DropDownList ID="stateList" runat="server" >
	                        <asp:ListItem Value="0">State</asp:ListItem>
                            <asp:ListItem Value="0">N/A</asp:ListItem>
	                        <asp:ListItem Value="AL">AL</asp:ListItem>
	                        <asp:ListItem Value="AK">AK</asp:ListItem>
	                        <asp:ListItem Value="AZ">AZ</asp:ListItem>
	                        <asp:ListItem Value="AR">AR</asp:ListItem>
	                        <asp:ListItem Value="CA">CA</asp:ListItem>
	                        <asp:ListItem Value="CO">CO</asp:ListItem>
	                        <asp:ListItem Value="CT">CT</asp:ListItem>
	                        <asp:ListItem Value="DC">DC</asp:ListItem>
	                        <asp:ListItem Value="DE">DE</asp:ListItem>
	                        <asp:ListItem Value="FL">FL</asp:ListItem>
	                        <asp:ListItem Value="GA">GA</asp:ListItem>
	                        <asp:ListItem Value="HI">HI</asp:ListItem>
	                        <asp:ListItem Value="ID">ID</asp:ListItem>
	                        <asp:ListItem Value="IL">IL</asp:ListItem>
	                        <asp:ListItem Value="IN">IN</asp:ListItem>
	                        <asp:ListItem Value="IA">IA</asp:ListItem>
	                        <asp:ListItem Value="KS">KS</asp:ListItem>
	                        <asp:ListItem Value="KY">KY</asp:ListItem>
	                        <asp:ListItem Value="LA">LA</asp:ListItem>
	                        <asp:ListItem Value="ME">ME</asp:ListItem>
	                        <asp:ListItem Value="MD">MD</asp:ListItem>
	                        <asp:ListItem Value="MA">MA</asp:ListItem>
	                        <asp:ListItem Value="MI">MI</asp:ListItem>
	                        <asp:ListItem Value="MN">MN</asp:ListItem>
	                        <asp:ListItem Value="MS">MS</asp:ListItem>
	                        <asp:ListItem Value="MO">MO</asp:ListItem>
	                        <asp:ListItem Value="MT">MT</asp:ListItem>
	                        <asp:ListItem Value="NE">NE</asp:ListItem>
	                        <asp:ListItem Value="NV">NV</asp:ListItem>
	                        <asp:ListItem Value="NH">NH</asp:ListItem>
	                        <asp:ListItem Value="NJ">NJ</asp:ListItem>
	                        <asp:ListItem Value="NM">NM</asp:ListItem>
	                        <asp:ListItem Value="NY">NY</asp:ListItem>
	                        <asp:ListItem Value="NC">NC</asp:ListItem>
	                        <asp:ListItem Value="ND">ND</asp:ListItem>
	                        <asp:ListItem Value="OH">OH</asp:ListItem>
	                        <asp:ListItem Value="OK">OK</asp:ListItem>
	                        <asp:ListItem Value="OR">OR</asp:ListItem>
	                        <asp:ListItem Value="PA">PA</asp:ListItem>
	                        <asp:ListItem Value="RI">RI</asp:ListItem>
	                        <asp:ListItem Value="SC">SC</asp:ListItem>
	                        <asp:ListItem Value="SD">SD</asp:ListItem>
	                        <asp:ListItem Value="TN">TN</asp:ListItem>
	                        <asp:ListItem Value="TX">TX</asp:ListItem>
	                        <asp:ListItem Value="UT">UT</asp:ListItem>
	                        <asp:ListItem Value="VT">VT</asp:ListItem>
	                        <asp:ListItem Value="VA">VA</asp:ListItem>
	                        <asp:ListItem Value="WA">WA</asp:ListItem>
	                        <asp:ListItem Value="WV">WV</asp:ListItem>
	                        <asp:ListItem Value="WI">WI</asp:ListItem>
	                        <asp:ListItem Value="WY">WY</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;&nbsp;Country: </td>
                    <td>
                        <asp:DropDownList ID="countryList" runat="server" >
	                        <asp:ListItem Value="">Country</asp:ListItem>
                            <asp:ListItem Value="US">US</asp:ListItem>
                            <asp:ListItem Value="FR">FR</asp:ListItem>
                            <asp:ListItem Value="DE">DE</asp:ListItem>
                            <asp:ListItem Value="PO">PO</asp:ListItem>
                            <asp:ListItem Value="IT">IT</asp:ListItem>
                            <asp:ListItem Value="PL">PL</asp:ListItem>
                        </asp:DropDownList>     
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ZipCode: </td>
                    <td>
                        <asp:TextBox ID="zipcode" runat="server"></asp:TextBox>
                    </td>
                </tr>
                
                <tr><td>&nbsp;&nbsp;</td></tr>
                <tr><td> <br /> </td><td></td><td></td><td></td>
                    <td>Last Updated:</td>
                    <td><asp:TextBox ID="lastUpdated" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>PropertyID: </td>
                    <td>
                         <asp:DropDownList ID="propertyIDDropDownList" runat="server" DataSourceID="SqlDataSource2" DataTextField="PropertyID" DataValueField="PropertyID" AppendDataBoundItems ="true" >                  
                             <asp:ListItem Value="0">N/A</asp:ListItem> 
                        </asp:DropDownList>
                         <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:lab2ConnectionString %>" SelectCommand="SELECT [PropertyID] FROM [Property]"></asp:SqlDataSource>
                    </td>
                    <td></td><td></td>
                    <td>Last Updated By: </td>
                    <td>
                        <asp:TextBox ID="lastUpdatedBy" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr><td></td>
                    <td></td><td></td><td></td>
                    
                </tr>
                
                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>                      
                        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" Width="100px" /> 
                    </td>
                    <td>&nbsp;&nbsp;&nbsp; &nbsp;</td>
                    <td>
                        <asp:Button ID="BtnCommit" runat="server" Text="Commit" OnClick="BtnCommit_Click" Width="100px" />
                    </td>
                    <td>&nbsp;&nbsp;&nbsp; &nbsp;</td>
                    <td>
                        <asp:Button ID="btnPopulate" runat="server" Text="Populate" OnClick="btnPopulate_Click" Width="100px" />
                    </td>
                    <td>&nbsp;&nbsp;&nbsp; &nbsp;</td>
                    <td>
                        <asp:Button ID="btnExit" runat="server" Text="Exit" OnClick="btnExit_Click" Width="100px" />
                    </td>
                    <td>&nbsp;&nbsp;&nbsp; &nbsp;</td>
                    <td>
                        <asp:Button ID="showGridView" runat="server" OnClick="showGridView_Click" Text="Show GridView" Width="140px" />
                    </td>
                </tr> 
                <tr><td></td></tr>
            </table>
            <asp:TextBox ID="outputBox" runat="server" Width="576px" Height="49px"></asp:TextBox>
            
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>

            <br />
            <br />
        </div>
</asp:Content>


