<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="DataStatistics.aspx.cs" Inherits="WebApplication2.DataStatistics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/echarts.js"></script>
    <script type="text/javascript"> 
            function lineChart() { //折线图
                //初始化echarts实例数据
                var myChart = echarts.init(document.getElementById('main'));
                var title = "<%=title%>";//图的标题
                var legend = "<%=legend%>";  //            
                var x_title = "<%=x_title%>";//X轴标题
                var y_title = "<%=y_title%>";//Y轴标题
                var x_count = "<%=x_count%>";//X轴数据个数
                var x_value = new Array();//X轴数据
                var y_value = new Array();//Y轴数据
                <%
                for (int k = 0; k < x_count; k++)
                {
                 %>
                    x_value.push("<%=x_values[k]%>");
                    y_value.push("<%=y_values[k]%>");        
                <%
                }
                %>
                //指定图表的配置项和数据
                var option = {
                    title: {
                        text: title
                    },
                    tooltip: {},
                    legend: {
                        data: legend
                    },
                    xAxis: {
                        name: x_title,
                        data: x_value
                    },
                    yAxis: {},
                    series: [{
                        name: y_title,
                        type: 'line',//图的类型，line折线图
                        data: y_value
                    }]
                };
                //使用刚指定的配置项和数据显示图表
                myChart.setOption(option);
            }

        function barChart() { //条形图
           //初始化echarts实例数据
           var myChart = echarts.init(document.getElementById('main'));
           var title = "<%=title%>";//图的标题
           var legend = "<%=legend%>";  //            
           var x_title = "<%=x_title%>";//X轴标题
           var y_title = "<%=y_title%>";//Y轴标题
           var x_count = "<%=x_count%>";//X轴数据个数
           var x_value = [];//X轴数据
           var y_value = [];//Y轴数据
           <%
            for (int k = 0; k < x_count; k++)
            {
             %>
           x_value.push("<%=x_values[k]%>");
           y_value.push("<%=y_values[k]%>");
           <%
            }
            %>
 //指定图表的配置项和数据
           var option = {
               title: {
                   text: title
               },
               tooltip: {},
               legend: {
                   data: legend
               },
               xAxis: {
                   name: x_title,
                   data: x_value,
                   axisLabel: {
                       interval: 0,
                       rotate:10
                    }

               },
               yAxis: {},
               series: [{
                   name: y_title,
	               type: 'bar',//图的类型，柱图
                   data: y_value
               }],
               label: {
                    show: true,
		            position: 'top',
		            color:'black'}
                    };
           //使用刚指定的配置项和数据显示图表
           myChart.setOption(option);
        }

        function pieChart(){//饼图
             //初始化echarts实例
             var myChart = echarts.init(document.getElementById('main'));
            var pietitle = "<%=title%>";//图的标题
            var x_count = "<%=x_count%>";
            var y_value = [];
             <%
            for (int k = 0; k < x_count; k++)
            {
             %>
             y_value.push({
                 name: "<%=x_values[k]%>",
                 value: "<%=y_values[k]%>"
             });
           <%
            }
            %>
  // 指定图表的配置项和数据
        var option = {
            title: {
                text: pietitle,
                left: 'center'
              },
              tooltip: {
                trigger: 'item'
              },
              legend: {
                orient: 'vertical',
                left: 'left'
              },
              series: [
                {
                  name: '销售额',
                  type: 'pie',
                  radius: '50%',
                  data: y_value,
                  emphasis: {
                    itemStyle: {
                      shadowBlur: 10,
                      shadowOffsetX: 0,
                      shadowColor: 'rgba(0, 0, 0, 0.5)'
                    }
                  }
                }
              ]
            };            //使用刚指定的配置项和数据显示图表
            myChart.setOption(option);
         }
</script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:100%">
        
        <asp:DropDownList ID="ddlCondition1" runat="server" style="margin-left:30%" AutoPostBack="True" OnSelectedIndexChanged="ddlCondition1_SelectedIndexChanged">
                    <asp:ListItem>热销商品</asp:ListItem>
                    <asp:ListItem>商品销量</asp:ListItem>
                    <asp:ListItem>销售额</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="ddlCondition2" runat="server"  style="margin-left:5%;width:30%">
                    <asp:ListItem>今日内</asp:ListItem>
                    <asp:ListItem>一周内</asp:ListItem>
                    <asp:ListItem>一月内</asp:ListItem>
                    <asp:ListItem>一季度内</asp:ListItem>
                    <asp:ListItem>半年内</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="BtnDisplay" runat="server" Text="获取" style="margin-left:5%" OnClick="BtnDisplay_Click"/>
    </div>
    
    <div id="main" style="margin:auto;width: 600px;height: 400px;" ></div>
</asp:Content>
