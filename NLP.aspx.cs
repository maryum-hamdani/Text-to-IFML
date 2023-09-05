using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;



public partial class NLP : System.Web.UI.Page
{
    string MaximumEntropyModelDirectory = "~/data/OpenNLP/Models/";
    // string WordnetSearchDirectory = "~/data/OpenNLP/WordNet/2.1/dict";
    string mModelPath = "";

    private OpenNLP.Tools.SentenceDetect.MaximumEntropySentenceDetector mSentenceDetector;
    private OpenNLP.Tools.Tokenize.EnglishMaximumEntropyTokenizer mTokenizer;
    private OpenNLP.Tools.PosTagger.EnglishMaximumEntropyPosTagger mPosTagger;
    private OpenNLP.Tools.Parser.EnglishTreebankParser mParser;
    private OpenNLP.Tools.NameFind.EnglishNameFinder mNameFinder;
    string[] sentences;


    protected void Page_Load(object sender, EventArgs e)
    {



        mModelPath = Server.MapPath(MaximumEntropyModelDirectory);


    }

    protected void POS_Token_Split_Sentence()
    {
        SqlConnection aConnection = new SqlConnection(getConnectionString());
        aConnection.Open();




        SqlCommand Cmd1 = new SqlCommand("truncate table table_ViewContainers", aConnection);
        Cmd1.ExecuteNonQuery();



        Cmd1 = new SqlCommand("truncate table table_ViewComponent", aConnection);
        Cmd1.ExecuteNonQuery();

        Cmd1 = new SqlCommand("truncate table table_Parameters", aConnection);
        Cmd1.ExecuteNonQuery();

        Cmd1 = new SqlCommand("truncate table table_Actions", aConnection);
        Cmd1.ExecuteNonQuery();

        Cmd1 = new SqlCommand("truncate table table_Events", aConnection);
        Cmd1.ExecuteNonQuery();

        string navigation1, navigation2, navigation3, navigation4, navigation5;


        mModelPath = Server.MapPath(MaximumEntropyModelDirectory);
        StringBuilder output = new StringBuilder();

        string text = TextBox1.Text;

        string mytext = Regex.Replace(text, @"[!@$%^&*()_+{}:;”“<>,?/~`\']", "");

        string mytext1 = Regex.Replace(mytext, @"((i\.e\. )|(e\.g\. )|(etc))", "");
        string mytext2 = Regex.Replace(mytext1, "\"", "");
        string mytext3 = Regex.Replace(mytext2, "-", "");

        sentences = SplitSentences(mytext3);

        foreach (string sentence in sentences)
        {
            output.Clear();
            string[] tokens = TokenizeSentence(sentence);
            string[] tags = PosTagTokens(tokens);

            for (int mycount = 0; mycount < tags.Length; mycount++)
            {
                tags[mycount] = tags[mycount].Replace("NNS", "NN");
                tags[mycount] = tags[mycount].Replace("NNP", "NN");
            }

            for (int currentTag = 0; currentTag < tags.Length; currentTag++)
            {
                output.Append(tokens[currentTag]).Append("/").Append(tags[currentTag]).Append(" ");
            }

            output.Append("\r\n\r\n");


            string Final_Output_Pos_ViewContainer1 = output.ToString();

            var matchexprViewContainer1 = new Regex(@"(\w+/DT \w+/JJ \w+/NN \w+/VBZ)");

            var matchViewContainer1 = matchexprViewContainer1.Matches(Final_Output_Pos_ViewContainer1);
            string afterposViewContainer1 = "";
            foreach (var item in matchViewContainer1)
            {
                afterposViewContainer1 = item.ToString();
            }
            string[] arrViewContainer1 = afterposViewContainer1.Split(' ');
            string ViewContainer1 = "";
            foreach (string spt in arrViewContainer1)
            {
                var findslash = new Regex(@"/");
                var matchslash = findslash.Matches(spt);
                if (matchslash.Count != 0)
                {
                    ViewContainer1 += spt.Substring(0, spt.LastIndexOf("/")) + " ";



                }
                else
                {
                    ViewContainer1 += spt;
                }
            }









            string Final_Output_Pos_ViewContainer1_1 = afterposViewContainer1.ToString();

            var matchexprViewContainer1_1 = new Regex(@"(\w+/JJ \w+/NN)");

            var matchViewContainer1_1 = matchexprViewContainer1_1.Matches(Final_Output_Pos_ViewContainer1_1);
            string afterposViewContainer1_1 = "";
            foreach (var item in matchViewContainer1_1)
            {
                afterposViewContainer1_1 = item.ToString();
            }
            string[] arrViewContainer1_1 = afterposViewContainer1_1.Split(' ');
            string ViewContainer1_1 = "";
            foreach (string spt1_1 in arrViewContainer1_1)
            {
                var findslash1_1 = new Regex(@"/");
                var matchslash1_1 = findslash1_1.Matches(spt1_1);
                if (matchslash1_1.Count != 0)
                {
                    ViewContainer1_1 += spt1_1.Substring(0, spt1_1.LastIndexOf("/")) + " ";
                }
                else
                {
                    ViewContainer1_1 += spt1_1;
                }
            }



            string Final_Output_Pos_ViewContainer2 = output.ToString();

            var matchexprViewContainer2 = new Regex(@"(\w+/VBZ (\w+/IN |to/TO )?\w+/VB \w+/NN \w+/NN)");

            var matchViewContainer2 = matchexprViewContainer2.Matches(Final_Output_Pos_ViewContainer2);
            string afterposViewContainer2 = "";
            foreach (var item in matchViewContainer2)
            {
                afterposViewContainer2 = item.ToString();
            }
            string[] arrViewContainer2 = afterposViewContainer2.Split(' ');
            string ViewContainer2 = "";
            foreach (string spt in arrViewContainer2)
            {
                var findslash = new Regex(@"/");
                var matchslash = findslash.Matches(spt);
                if (matchslash.Count != 0)
                {
                    ViewContainer2 += spt.Substring(0, spt.LastIndexOf("/")) + " ";
                }
                else
                {
                    ViewContainer2 += spt;
                }
            }

            string Final_Output_Pos_ViewContainer2_1 = afterposViewContainer2.ToString();

            var matchexprViewContainer2_1 = new Regex(@"(\w+/VB \w+/NN \w+/NN)");

            var matchViewContainer2_1 = matchexprViewContainer2_1.Matches(Final_Output_Pos_ViewContainer2_1);
            string afterposViewContainer2_1 = "";
            foreach (var item in matchViewContainer2_1)
            {
                afterposViewContainer2_1 = item.ToString();
            }
            string[] arrViewContainer2_1 = afterposViewContainer2_1.Split(' ');
            string ViewContainer2_1 = "";
            foreach (string spt2_1 in arrViewContainer2_1)
            {
                var findslash2_1 = new Regex(@"/");
                var matchslash2_1 = findslash2_1.Matches(spt2_1);
                if (matchslash2_1.Count != 0)
                {
                    ViewContainer2_1 += spt2_1.Substring(0, spt2_1.LastIndexOf("/")) + " ";
                }
                else
                {
                    ViewContainer2_1 += spt2_1;
                }
            }


            string Final_Output_Pos_ViewContainer3 = output.ToString();

            var matchexprViewContainer3 = new Regex(@"((\w+/NN \w+/NN (\w+/WDT )?\w+/VBZ)|((\w+/NN|\w+/VB) \w+/NN \w+/NN (\w+/WDT )?\w+/VBZ))");

            var matchViewContainer3 = matchexprViewContainer3.Matches(Final_Output_Pos_ViewContainer3);
            string afterposViewContainer3 = "";
            foreach (var item in matchViewContainer3)
            {
                afterposViewContainer3 = item.ToString();
            }
            string[] arrViewContainer3 = afterposViewContainer3.Split(' ');
            string ViewContainer3 = "";
            foreach (string spt in arrViewContainer3)
            {
                var findslash = new Regex(@"/");
                var matchslash = findslash.Matches(spt);
                if (matchslash.Count != 0)
                {
                    ViewContainer3 += spt.Substring(0, spt.LastIndexOf("/")) + " ";
                }
                else
                {
                    ViewContainer3 += spt;
                }
            }


            string Final_Output_Pos_ViewContainer3_1 = afterposViewContainer3.ToString();

            var matchexprViewContainer3_1 = new Regex(@"((\w+/NN|\w+/VB) \w+/NN (\w+/NN)?)");

            var matchViewContainer3_1 = matchexprViewContainer3_1.Matches(Final_Output_Pos_ViewContainer3_1);
            string afterposViewContainer3_1 = "";
            foreach (var item in matchViewContainer3_1)
            {
                afterposViewContainer3_1 = item.ToString();
            }
            string[] arrViewContainer3_1 = afterposViewContainer3_1.Split(' ');
            string ViewContainer3_1 = "";
            foreach (string spt3_1 in arrViewContainer3_1)
            {
                var findslash3_1 = new Regex(@"/");
                var matchslash3_1 = findslash3_1.Matches(spt3_1);
                if (matchslash3_1.Count != 0)
                {
                    ViewContainer3_1 += spt3_1.Substring(0, spt3_1.LastIndexOf("/")) + " ";
                }
                else
                {
                    ViewContainer3_1 += spt3_1;
                }
            }




            string Final_Output_Pos_ViewContainer4 = output.ToString();

            var matchexprViewContainer4 = new Regex(@"(\w+/VBN (\w+/IN |to/TO )?\w+/JJ \w+/NN)");

            var matchViewContainer4 = matchexprViewContainer4.Matches(Final_Output_Pos_ViewContainer4);
            string afterposViewContainer4 = "";
            foreach (var item in matchViewContainer4)
            {
                afterposViewContainer4 = item.ToString();
            }
            string[] arrViewContainer4 = afterposViewContainer4.Split(' ');
            string ViewContainer4 = "";
            foreach (string spt in arrViewContainer4)
            {
                var findslash = new Regex(@"/");
                var matchslash = findslash.Matches(spt);
                if (matchslash.Count != 0)
                {
                    ViewContainer4 += spt.Substring(0, spt.LastIndexOf("/")) + " ";
                }
                else
                {
                    ViewContainer4 += spt;
                }
            }


            string Final_Output_Pos_ViewContainer4_1 = afterposViewContainer4.ToString();

            var matchexprViewContainer4_1 = new Regex(@"(\w+/JJ \w+/NN)");

            var matchViewContainer4_1 = matchexprViewContainer4_1.Matches(Final_Output_Pos_ViewContainer4_1);
            string afterposViewContainer4_1 = "";
            foreach (var item in matchViewContainer4_1)
            {
                afterposViewContainer4_1 = item.ToString();
            }
            string[] arrViewContainer4_1 = afterposViewContainer4_1.Split(' ');
            string ViewContainer4_1 = "";
            foreach (string spt4_1 in arrViewContainer4_1)
            {
                var findslash4_1 = new Regex(@"/");
                var matchslash4_1 = findslash4_1.Matches(spt4_1);
                if (matchslash4_1.Count != 0)
                {
                    ViewContainer4_1 += spt4_1.Substring(0, spt4_1.LastIndexOf("/")) + " ";
                }
                else
                {
                    ViewContainer4_1 += spt4_1;
                }
            }




            string Final_Output_Pos_ViewContainer5 = output.ToString();

            var matchexprViewContainer5 = new Regex(@"(\w+/VBZ (\w+/DT )?(\w+/IN |to/TO )?\w+/NN \w+/NN)");

            var matchViewContainer5 = matchexprViewContainer5.Matches(Final_Output_Pos_ViewContainer5);
            string afterposViewContainer5 = "";
            foreach (var item in matchViewContainer5)
            {
                afterposViewContainer5 = item.ToString();
            }
            string[] arrViewContainer5 = afterposViewContainer5.Split(' ');
            string ViewContainer5 = "";
            foreach (string spt in arrViewContainer5)
            {
                var findslash = new Regex(@"/");
                var matchslash = findslash.Matches(spt);
                if (matchslash.Count != 0)
                {
                    ViewContainer5 += spt.Substring(0, spt.LastIndexOf("/")) + " ";
                }
                else
                {
                    ViewContainer5 += spt;
                }
            }
            //lbl_Total.InnerText = ViewContainer5.ToString();




            string Final_Output_Pos_ViewContainer5_1 = afterposViewContainer5.ToString();

            var matchexprViewContainer5_1 = new Regex(@"(\w+/NN \w+/NN)");

            var matchViewContainer5_1 = matchexprViewContainer5_1.Matches(Final_Output_Pos_ViewContainer5_1);
            string afterposViewContainer5_1 = "";
            foreach (var item in matchViewContainer5_1)
            {
                afterposViewContainer5_1 = item.ToString();
            }
            string[] arrViewContainer5_1 = afterposViewContainer5_1.Split(' ');
            string ViewContainer5_1 = "";
            foreach (string spt5_1 in arrViewContainer5_1)
            {
                var findslash5_1 = new Regex(@"/");
                var matchslash5_1 = findslash5_1.Matches(spt5_1);
                if (matchslash5_1.Count != 0)
                {
                    ViewContainer5_1 += spt5_1.Substring(0, spt5_1.LastIndexOf("/")) + " ";
                }
                else
                {
                    ViewContainer5_1 += spt5_1;
                }
            }


            string Final_Output_Pos_ViewContainer6 = output.ToString();
            var matchexprViewContainer6 = new Regex(@"(\w+/VBN (\w+/IN |to/TO )\w+/NN \w+/NN)");
            var matchViewContainer6 = matchexprViewContainer6.Matches(Final_Output_Pos_ViewContainer6);
            string afterposViewContainer6 = "";
            foreach (var item in matchViewContainer6)
            {
                afterposViewContainer6 = item.ToString();
            }
            string[] arrViewContainer6 = afterposViewContainer6.Split(' ');
            string ViewContainer6 = "";
            foreach (string spt in arrViewContainer6)
            {
                var findslash = new Regex(@"/");
                var matchslash = findslash.Matches(spt);
                if (matchslash.Count != 0)
                {
                    ViewContainer6 += spt.Substring(0, spt.LastIndexOf("/")) + " ";
                }
                else
                {
                    ViewContainer6 += spt;
                }
            }


            string Final_Output_Pos_ViewContainer6_1 = afterposViewContainer6.ToString();

            var matchexprViewContainer6_1 = new Regex(@"(\w+/NN \w+/NN)");

            var matchViewContainer6_1 = matchexprViewContainer6_1.Matches(Final_Output_Pos_ViewContainer6_1);
            string afterposViewContainer6_1 = "";
            foreach (var item in matchViewContainer6_1)
            {
                afterposViewContainer6_1 = item.ToString();
            }
            string[] arrViewContainer6_1 = afterposViewContainer6_1.Split(' ');
            string ViewContainer6_1 = "";
            foreach (string spt6_1 in arrViewContainer6_1)
            {
                var findslash6_1 = new Regex(@"/");
                var matchslash6_1 = findslash6_1.Matches(spt6_1);
                if (matchslash6_1.Count != 0)
                {
                    ViewContainer6_1 += spt6_1.Substring(0, spt6_1.LastIndexOf("/")) + " ";
                }
                else
                {
                    ViewContainer6_1 += spt6_1;
                }
            }



            //    lbl_TestAble.InnerText = ViewContainer6.ToString();

            string sentence1 = sentence.Replace("'", "");

            ViewContainer6 = ViewContainer6.Replace("'", "");
            ViewContainer5 = ViewContainer5.Replace("'", "");
            string status = "";
            if (ViewContainer5 == "")
            {
                status = "no";
            }
            else
            {
                status = "yes";
            }

            Final_Output_Pos_ViewContainer6 = Final_Output_Pos_ViewContainer6.Replace("'", "");
            SqlCommand Cmd = new SqlCommand("INSERT INTO table_ViewContainers (strRequirement,strViewContainer1,strViewContainer2, strViewContainer3, strViewContainer4,strViewContainer5_1,strViewContainer5_2,strViewContainer1_1,strViewContainer2_1, strViewContainer3_1, strViewContainer4_1,strViewContainer55_1,strViewContainer6_1) Values ('" + sentence1 + "' ,'" + ViewContainer1 + "' ,'" + ViewContainer2 + "' ,'" + ViewContainer3 + "' ,'" + ViewContainer4 + "','" + ViewContainer5 + "','" + ViewContainer6 + "','" + ViewContainer1_1 + "' ,'" + ViewContainer2_1 + "' ,'" + ViewContainer3_1 + "' ,'" + ViewContainer4_1 + "','" + ViewContainer5_1 + "','" + ViewContainer6_1 + "')", aConnection);
            Cmd.ExecuteNonQuery();



            string Final_Output_Pos_ViewComponent1 = output.ToString();

            var matchexprViewComponent1 = new Regex(@"(\w+/VBZ (\w+/DT )?\w+/NN (\w+/IN |\w+/TO )\w+/NN)");

            var matchViewComponent1 = matchexprViewComponent1.Matches(Final_Output_Pos_ViewComponent1);
            string afterposViewComponent1 = "";
            foreach (var item in matchViewComponent1)
            {
                afterposViewComponent1 = item.ToString();
            }
            string[] arrViewComponent1 = afterposViewComponent1.Split(' ');
            string ViewComponent1 = "";
            foreach (string spt in arrViewComponent1)
            {
                var findslash = new Regex(@"/");
                var matchslash = findslash.Matches(spt);
                if (matchslash.Count != 0)
                {
                    ViewComponent1 += spt.Substring(0, spt.LastIndexOf("/")) + " ";
                }
                else
                {
                    ViewComponent1 += spt;
                }
            }





            string Final_Output_Pos_ViewComponent1_1 = afterposViewComponent1.ToString();

            var matchexprViewComponent1_1 = new Regex(@"(\w+/NN (\w+/IN |\w+/TO )\w+/NN)");

            var matchViewComponent1_1 = matchexprViewComponent1_1.Matches(Final_Output_Pos_ViewComponent1_1);
            string afterposViewComponent1_1 = "";
            foreach (var item in matchViewComponent1_1)
            {
                afterposViewComponent1_1 = item.ToString();
            }
            string[] arrViewComponent1_1 = afterposViewComponent1_1.Split(' ');
            string ViewComponent1_1 = "";
            foreach (string sptComponent1_1 in arrViewComponent1_1)
            {
                var findslashComponent1_1 = new Regex(@"/");
                var matchslashComponent1_1 = findslashComponent1_1.Matches(sptComponent1_1);
                if (matchslashComponent1_1.Count != 0)
                {
                    ViewComponent1_1 += sptComponent1_1.Substring(0, sptComponent1_1.LastIndexOf("/")) + " ";
                }
                else
                {
                    ViewComponent1_1 += sptComponent1_1;
                }
            }




            string Final_Output_Pos_ViewComponent2 = output.ToString();

            var matchexprViewComponent2 = new Regex(@"(\w+/VBZ ((\w+/DT|\w+/IN))? \w+/NN \w+/IN \w+/VBG \w+/NN)");

            var matchViewComponent2 = matchexprViewComponent2.Matches(Final_Output_Pos_ViewComponent2);
            string afterposViewComponent2 = "";
            foreach (var item in matchViewComponent2)
            {
                afterposViewComponent2 = item.ToString();
            }
            string[] arrViewComponent2 = afterposViewComponent2.Split(' ');
            string ViewComponent2 = "";
            foreach (string spt in arrViewComponent2)
            {
                var findslash = new Regex(@"/");
                var matchslash = findslash.Matches(spt);
                if (matchslash.Count != 0)
                {
                    ViewComponent2 += spt.Substring(0, spt.LastIndexOf("/")) + " ";
                }
                else
                {
                    ViewComponent2 += spt;
                }
            }




            string Final_Output_Pos_ViewComponent2_1 = afterposViewComponent2.ToString();

            var matchexprViewComponent2_1 = new Regex(@"(\w+/NN \w+/IN \w+/VBG \w+/NN)");

            var matchViewComponent2_1 = matchexprViewComponent2_1.Matches(Final_Output_Pos_ViewComponent2_1);
            string afterposViewComponent2_1 = "";
            foreach (var item in matchViewComponent2_1)
            {
                afterposViewComponent2_1 = item.ToString();
            }
            string[] arrViewComponent2_1 = afterposViewComponent2_1.Split(' ');
            string ViewComponent2_1 = "";
            foreach (string sptComponent2_1 in arrViewComponent2_1)
            {
                var findslashComponent2_1 = new Regex(@"/");
                var matchslashComponent2_1 = findslashComponent2_1.Matches(sptComponent2_1);
                if (matchslashComponent2_1.Count != 0)
                {
                    ViewComponent2_1 += sptComponent2_1.Substring(0, sptComponent2_1.LastIndexOf("/")) + " ";
                }
                else
                {
                    ViewComponent2_1 += sptComponent2_1;
                }
            }


            string Final_Output_Pos_ViewComponent3 = output.ToString();

            var matchexprViewComponent3 = new Regex(@"(\w+/NN \w+/IN \w+/NN \w+/VBN)");

            var matchViewComponent3 = matchexprViewComponent3.Matches(Final_Output_Pos_ViewComponent3);
            string afterposViewComponent3 = "";
            foreach (var item in matchViewComponent3)
            {
                afterposViewComponent3 = item.ToString();
            }
            string[] arrViewComponent3 = afterposViewComponent3.Split(' ');
            string ViewComponent3 = "";
            foreach (string spt in arrViewComponent3)
            {
                var findslash = new Regex(@"/");
                var matchslash = findslash.Matches(spt);
                if (matchslash.Count != 0)
                {
                    ViewComponent3 += spt.Substring(0, spt.LastIndexOf("/")) + " ";
                }
                else
                {
                    ViewComponent3 += spt;
                }
            }




            string Final_Output_Pos_ViewComponent3_1 = afterposViewComponent3.ToString();

            var matchexprViewComponent3_1 = new Regex(@"(\w+/NN \w+/IN \w+/NN)");

            var matchViewComponent3_1 = matchexprViewComponent3_1.Matches(Final_Output_Pos_ViewComponent3_1);
            string afterposViewComponent3_1 = "";
            foreach (var item in matchViewComponent3_1)
            {
                afterposViewComponent3_1 = item.ToString();
            }
            string[] arrViewComponent3_1 = afterposViewComponent3_1.Split(' ');
            string ViewComponent3_1 = "";
            foreach (string sptComponent3_1 in arrViewComponent3_1)
            {
                var findslashComponent3_1 = new Regex(@"/");
                var matchslashComponent3_1 = findslashComponent3_1.Matches(sptComponent3_1);
                if (matchslashComponent3_1.Count != 0)
                {
                    ViewComponent3_1 += sptComponent3_1.Substring(0, sptComponent3_1.LastIndexOf("/")) + " ";
                }
                else
                {
                    ViewComponent3_1 += sptComponent3_1;
                }
            }




            string Final_Output_Pos_ViewComponent4 = output.ToString();

            var matchexprViewComponent4 = new Regex(@"(\w+/VBZ (\w+/DT )?\w+/NN \w+/IN \w+/VBN \w+/NN)");

            var matchViewComponent4 = matchexprViewComponent4.Matches(Final_Output_Pos_ViewComponent4);
            string afterposViewComponent4 = "";
            foreach (var item in matchViewComponent4)
            {
                afterposViewComponent4 = item.ToString();
            }
            string[] arrViewComponent4 = afterposViewComponent4.Split(' ');
            string ViewComponent4 = "";
            foreach (string spt in arrViewComponent4)
            {
                var findslash = new Regex(@"/");
                var matchslash = findslash.Matches(spt);
                if (matchslash.Count != 0)
                {
                    ViewComponent4 += spt.Substring(0, spt.LastIndexOf("/")) + " ";
                }
                else
                {
                    ViewComponent4 += spt;
                }
            }



            string Final_Output_Pos_ViewComponent4_1 = afterposViewComponent4.ToString();

            var matchexprViewComponent4_1 = new Regex(@"(\w+/NN \w+/IN \w+/VBN \w+/NN)");

            var matchViewComponent4_1 = matchexprViewComponent4_1.Matches(Final_Output_Pos_ViewComponent4_1);
            string afterposViewComponent4_1 = "";
            foreach (var item in matchViewComponent4_1)
            {
                afterposViewComponent4_1 = item.ToString();
            }
            string[] arrViewComponent4_1 = afterposViewComponent4_1.Split(' ');
            string ViewComponent4_1 = "";
            foreach (string sptComponent4_1 in arrViewComponent4_1)
            {
                var findslashComponent4_1 = new Regex(@"/");
                var matchslashComponent4_1 = findslashComponent4_1.Matches(sptComponent4_1);
                if (matchslashComponent4_1.Count != 0)
                {
                    ViewComponent4_1 += sptComponent4_1.Substring(0, sptComponent4_1.LastIndexOf("/")) + " ";
                }
                else
                {
                    ViewComponent4_1 += sptComponent4_1;
                }
            }



            string Final_Output_Pos_ViewComponent5 = output.ToString();

            var matchexprViewComponent5 = new Regex(@"((\w+/VBZ (\w+/DT )?\w+/NN (\w+/IN |\w+/TO )\w+/JJ \w+/NN)| (\w+/NN (\w+/IN |\w+/TO )\w+/JJ \w+/NN \w+/VBZ))");

            var matchViewComponent5 = matchexprViewComponent5.Matches(Final_Output_Pos_ViewComponent5);
            string afterposViewComponent5 = "";
            foreach (var item in matchViewComponent5)
            {
                afterposViewComponent5 = item.ToString();
            }
            string[] arrViewComponent5 = afterposViewComponent5.Split(' ');
            string ViewComponent5 = "";
            foreach (string spt in arrViewComponent5)
            {
                var findslash = new Regex(@"/");
                var matchslash = findslash.Matches(spt);
                if (matchslash.Count != 0)
                {
                    ViewComponent5 += spt.Substring(0, spt.LastIndexOf("/")) + " ";
                }
                else
                {
                    ViewComponent5 += spt;
                }
            }


            string Final_Output_Pos_ViewComponent5_1 = afterposViewComponent5.ToString();

            var matchexprViewComponent5_1 = new Regex(@"(\w+/NN (\w+/IN |\w+/TO )\w+/JJ \w+/NN)");

            var matchViewComponent5_1 = matchexprViewComponent5_1.Matches(Final_Output_Pos_ViewComponent5_1);
            string afterposViewComponent5_1 = "";
            foreach (var item in matchViewComponent5_1)
            {
                afterposViewComponent5_1 = item.ToString();
            }
            string[] arrViewComponent5_1 = afterposViewComponent5_1.Split(' ');
            string ViewComponent5_1 = "";
            foreach (string sptComponent5_1 in arrViewComponent5_1)
            {
                var findslashComponent5_1 = new Regex(@"/");
                var matchslashComponent5_1 = findslashComponent5_1.Matches(sptComponent5_1);
                if (matchslashComponent5_1.Count != 0)
                {
                    ViewComponent5_1 += sptComponent5_1.Substring(0, sptComponent5_1.LastIndexOf("/")) + " ";
                }
                else
                {
                    ViewComponent5_1 += sptComponent5_1;
                }
            }


            string Final_Output_Pos_ViewComponent6 = output.ToString();

            var matchexprViewComponent6 = new Regex(@"(\w+/VBZ (\w+/DT )?\w+/NN (\w+/IN |\w+/TO )\w+/VB \w+/NN)");

            var matchViewComponent6 = matchexprViewComponent6.Matches(Final_Output_Pos_ViewComponent6);
            string afterposViewComponent6 = "";
            foreach (var item in matchViewComponent6)
            {
                afterposViewComponent6 = item.ToString();
            }
            string[] arrViewComponent6 = afterposViewComponent6.Split(' ');
            string ViewComponent6 = "";
            foreach (string spt in arrViewComponent6)
            {
                var findslash = new Regex(@"/");
                var matchslash = findslash.Matches(spt);
                if (matchslash.Count != 0)
                {
                    ViewComponent6 += spt.Substring(0, spt.LastIndexOf("/")) + " ";
                }
                else
                {
                    ViewComponent6 += spt;
                }
            }


            string Final_Output_Pos_ViewComponent6_1 = afterposViewComponent6.ToString();

            var matchexprViewComponent6_1 = new Regex(@"(\w+/NN (\w+/IN |\w+/TO )\w+/VB \w+/NN)");

            var matchViewComponent6_1 = matchexprViewComponent6_1.Matches(Final_Output_Pos_ViewComponent6_1);
            string afterposViewComponent6_1 = "";
            foreach (var item in matchViewComponent6_1)
            {
                afterposViewComponent6_1 = item.ToString();
            }
            string[] arrViewComponent6_1 = afterposViewComponent6_1.Split(' ');
            string ViewComponent6_1 = "";
            foreach (string sptComponent6_1 in arrViewComponent6_1)
            {
                var findslashComponent6_1 = new Regex(@"/");
                var matchslashComponent6_1 = findslashComponent6_1.Matches(sptComponent6_1);
                if (matchslashComponent6_1.Count != 0)
                {
                    ViewComponent6_1 += sptComponent6_1.Substring(0, sptComponent6_1.LastIndexOf("/")) + " ";
                }
                else
                {
                    ViewComponent6_1 += sptComponent6_1;
                }
            }

            if (ViewComponent1_1.Contains("list") || ViewComponent1_1.Contains("detail"))
            {
                ViewComponent1_1 = ViewComponent1_1 + "Databinding <" + TextBox2.Text + ">";
            }

            if (ViewComponent2_1.Contains("list") || ViewComponent2_1.Contains("detail"))
            {
                ViewComponent2_1 = ViewComponent2_1 + "Databinding <" + TextBox2.Text + ">";
            }
            if (ViewComponent3_1.Contains("list") || ViewComponent3_1.Contains("detail"))
            {
                ViewComponent3_1 = ViewComponent3_1 + "Databinding <" + TextBox2.Text + ">";
            }
            if (ViewComponent4_1.Contains("list") || ViewComponent4_1.Contains("detail"))
            {
                ViewComponent4_1 = ViewComponent4_1 + "Databinding <" + TextBox2.Text + ">";
            }
            if (ViewComponent5_1.Contains("list") || ViewComponent5_1.Contains("detail"))
            {
                ViewComponent5_1 = ViewComponent5_1 + "Databinding <" + TextBox2.Text + ">";
            }
            if (ViewComponent6_1.Contains("list") || ViewComponent6_1.Contains("detail"))
            {
                ViewComponent6_1 = ViewComponent6_1 + "Databinding <" + TextBox2.Text + ">";
            }
            SqlCommand Cmd2 = new SqlCommand("INSERT INTO table_ViewComponent (strRequirement,strViewComponent1,strViewComponent2, strViewComponent3, strViewComponent4, strViewComponent5, strViewComponent6,strViewComponent1_1,strViewComponent2_1, strViewComponent3_1, strViewComponent4_1, strViewComponent5_1, strViewComponent6_1) Values ('" + sentence1 + "' ,'" + ViewComponent1 + "' ,'" + ViewComponent2 + "' ,'" + ViewComponent3 + "' ,'" + ViewComponent4 + "','" + ViewComponent5 + "' ,'" + ViewComponent6 + "','" + ViewComponent1_1 + "' ,'" + ViewComponent2_1 + "' ,'" + ViewComponent3_1 + "' ,'" + ViewComponent4_1 + "','" + ViewComponent5_1 + "' ,'" + ViewComponent6_1 + "')", aConnection);
            Cmd2.ExecuteNonQuery();



            string Final_Output_Pos_Parameter1 = output.ToString();

            var matchexprParameter1 = new Regex(@"(\w+/NN of+/IN \w+/NN )");

            var matchParameter1 = matchexprParameter1.Matches(Final_Output_Pos_Parameter1);
            string afterposParameter1 = "";
            foreach (var item in matchParameter1)
            {
                afterposParameter1 = item.ToString();
            }
            string[] arrParameter1 = afterposParameter1.Split(' ');
            string Parameter1 = "";
            foreach (string spt in arrParameter1)
            {
                var findslash = new Regex(@"/");
                var matchslash = findslash.Matches(spt);
                if (matchslash.Count != 0)
                {
                    Parameter1 += spt.Substring(0, spt.LastIndexOf("/")) + " ";
                }
                else
                {
                    Parameter1 += spt;
                }
            }


            string Final_Output_Pos_Parameter2 = output.ToString();

            var matchexprParameter2 = new Regex(@"(\w+/VBN \w+/NN )");

            var matchParameter2 = matchexprParameter2.Matches(Final_Output_Pos_Parameter2);
            string afterposParameter2 = "";
            foreach (var item in matchParameter2)
            {
                afterposParameter2 = item.ToString();
            }
            string[] arrParameter2 = afterposParameter2.Split(' ');
            string Parameter2 = "";
            foreach (string spt in arrParameter2)
            {
                var findslash = new Regex(@"/");
                var matchslash = findslash.Matches(spt);
                if (matchslash.Count != 0)
                {
                    Parameter2 += spt.Substring(0, spt.LastIndexOf("/")) + " ";
                }
                else
                {
                    Parameter2 += spt;
                }
            }

            SqlCommand Cmd4 = new SqlCommand("INSERT INTO table_Parameters (strRequirement,strParameter1,strParameter2) Values ('" + sentence1 + "' ,'" + Parameter1 + "' ,'" + Parameter2 + "' )", aConnection);
            Cmd4.ExecuteNonQuery();






            string Final_Output_Pos_Event1 = output.ToString();
            var matchexprEvent1 = new Regex(@"((\w+/IN|\w+/TO) \w+/VB (\w+/JJ|\w+/DT) \w+/NN)");
            var matchEvent1 = matchexprEvent1.Matches(Final_Output_Pos_Event1);
            string afterposEvent1 = "";
            foreach (var item in matchEvent1)
            {
                afterposEvent1 = item.ToString();
            }
            string[] arrEvent1 = afterposEvent1.Split(' ');
            string Event1 = "";
            foreach (string spt in arrEvent1)
            {
                var findslash = new Regex(@"/");
                var matchslash = findslash.Matches(spt);
                if (matchslash.Count != 0)
                {
                    Event1 += spt.Substring(0, spt.LastIndexOf("/")) + " ";
                }
                else
                {
                    Event1 += spt;
                }
            }




            string Final_Output_Pos_Event1_1 = afterposEvent1.ToString();

            var matchexprEvent1_1 = new Regex(@"(\w+/VB (\w+/JJ)?)");

            var matchEvent1_1 = matchexprEvent1_1.Matches(Final_Output_Pos_Event1_1);
            string afterposEvent1_1 = "";
            foreach (var item in matchEvent1_1)
            {
                afterposEvent1_1 = item.ToString();
            }
            string[] arrEvent1_1 = afterposEvent1_1.Split(' ');
            string Event1_1 = "";
            foreach (string sptEvent1_1 in arrEvent1_1)
            {
                var findslashEvent1_1 = new Regex(@"/");
                var matchslashEvent1_1 = findslashEvent1_1.Matches(sptEvent1_1);
                if (matchslashEvent1_1.Count != 0)
                {
                    Event1_1 += sptEvent1_1.Substring(0, sptEvent1_1.LastIndexOf("/")) + " ";
                    if (Event1_1 != "")
                    {
                        navigation1 = "True";

                    }
                    else
                    {
                        navigation1 = "False";
                    }
                }
                else
                {
                    Event1_1 += sptEvent1_1;
                    if (Event1_1 != "")
                    {
                        navigation1 = "True";

                    }
                    else
                    {
                        navigation1 = "False";
                    }
                }
            }



            string Final_Output_Pos_Event2 = output.ToString();

            var matchexprEvent2 = new Regex(@"(\w+/VBG (\w+/JJ|\w+/NN) \w+/NN)");

            var matchEvent2 = matchexprEvent2.Matches(Final_Output_Pos_Event2);
            string afterposEvent2 = "";
            foreach (var item in matchEvent2)
            {
                afterposEvent2 = item.ToString();
            }
            string[] arrEvent2 = afterposEvent2.Split(' ');
            string Event2 = "";
            foreach (string spt in arrEvent2)
            {
                var findslash = new Regex(@"/");
                var matchslash = findslash.Matches(spt);
                if (matchslash.Count != 0)
                {
                    Event2 += spt.Substring(0, spt.LastIndexOf("/")) + " ";

                }
                else
                {
                    Event2 += spt;
                }
            }




            string Final_Output_Pos_Event2_1 = afterposEvent2.ToString();

            var matchexprEvent2_1 = new Regex(@"(\w+/JJ|\w+/NN )");

            var matchEvent2_1 = matchexprEvent2_1.Matches(Final_Output_Pos_Event2_1);
            string afterposEvent2_1 = "";
            foreach (var item in matchEvent2_1)
            {
                afterposEvent2_1 = item.ToString();
            }
            string[] arrEvent2_1 = afterposEvent2_1.Split(' ');
            string Event2_1 = "";
            foreach (string sptEvent2_1 in arrEvent2_1)
            {
                var findslashEvent2_1 = new Regex(@"/");
                var matchslashEvent2_1 = findslashEvent2_1.Matches(sptEvent2_1);
                if (matchslashEvent2_1.Count != 0)
                {
                    Event2_1 += sptEvent2_1.Substring(0, sptEvent2_1.LastIndexOf("/")) + " ";
                    if (Event2_1 != "")
                    {
                        navigation2 = "True";

                    }
                    else
                    {
                        navigation2 = "False";
                    }
                }
                else
                {
                    Event2_1 += sptEvent2_1;
                    if (Event2_1 != "")
                    {
                        navigation2 = "True";

                    }
                    else
                    {
                        navigation2 = "False";
                    }
                }
            }



            string Final_Output_Pos_Event3 = output.ToString();

            var matchexprEvent3 = new Regex(@"(\w+/VB (\w+/VBN|(\w+/CD (\w+/IN)? (\w+/DT)?)) \w+/NN)");

            var matchEvent3 = matchexprEvent3.Matches(Final_Output_Pos_Event3);
            string afterposEvent3 = "";
            foreach (var item in matchEvent3)
            {
                afterposEvent3 = item.ToString();
            }
            string[] arrEvent3 = afterposEvent3.Split(' ');
            string Event3 = "";
            foreach (string spt in arrEvent3)
            {
                var findslash = new Regex(@"/");
                var matchslash = findslash.Matches(spt);
                if (matchslash.Count != 0)
                {
                    Event3 += spt.Substring(0, spt.LastIndexOf("/")) + " ";
                }
                else
                {
                    Event3 += spt;
                }
            }





            string Final_Output_Pos_Event3_1 = afterposEvent3.ToString();


            var matchexprEvent3_1 = new Regex(@"(\w+/VB )");

            var matchEvent3_1 = matchexprEvent3_1.Matches(Final_Output_Pos_Event3_1);
            string afterposEvent3_1 = "";
            foreach (var item in matchEvent3_1)
            {
                afterposEvent3_1 = item.ToString();
            }
            string[] arrEvent3_1 = afterposEvent3_1.Split(' ');
            string Event3_1 = "";
            foreach (string sptEvent3_1 in arrEvent3_1)
            {
                var findslashEvent3_1 = new Regex(@"/");
                var matchslashEvent3_1 = findslashEvent3_1.Matches(sptEvent3_1);
                if (matchslashEvent3_1.Count != 0)
                {
                    Event3_1 += sptEvent3_1.Substring(0, sptEvent3_1.LastIndexOf("/")) + " ";
                }
                else
                {
                    Event3_1 += sptEvent3_1;
                }
            }



            string Final_Output_Pos_Event4 = output.ToString();

            var matchexprEvent4 = new Regex(@"(\w+/IN \w+/DT \w+/NN \w+/NN)");

            var matchEvent4 = matchexprEvent4.Matches(Final_Output_Pos_Event4);
            string afterposEvent4 = "";
            foreach (var item in matchEvent4)
            {
                afterposEvent4 = item.ToString();
            }
            string[] arrEvent4 = afterposEvent4.Split(' ');
            string Event4 = "";
            foreach (string spt in arrEvent4)
            {
                var findslash = new Regex(@"/");
                var matchslash = findslash.Matches(spt);
                if (matchslash.Count != 0)
                {
                    Event4 += spt.Substring(0, spt.LastIndexOf("/")) + " ";
                }
                else
                {
                    Event4 += spt;
                }
            }



            string Final_Output_Pos_Event4_1 = afterposEvent4.ToString();

            var matchexprEvent4_1 = new Regex(@"(\w+/NN )");

            var matchEvent4_1 = matchexprEvent4_1.Matches(Final_Output_Pos_Event4_1);
            string afterposEvent4_1 = "";
            foreach (var item in matchEvent4_1)
            {
                afterposEvent4_1 = item.ToString();
            }
            string[] arrEvent4_1 = afterposEvent4_1.Split(' ');
            string Event4_1 = "";
            foreach (string sptEvent4_1 in arrEvent4_1)
            {
                var findslashEvent4_1 = new Regex(@"/");
                var matchslashEvent4_1 = findslashEvent4_1.Matches(sptEvent4_1);
                if (matchslashEvent4_1.Count != 0)
                {
                    Event4_1 += sptEvent4_1.Substring(0, sptEvent4_1.LastIndexOf("/")) + " ";
                }
                else
                {
                    Event4_1 += sptEvent4_1;
                }
            }



            string Final_Output_Pos_Event5 = output.ToString();

            var matchexprEvent5 = new Regex(@"(\w+/VBP (\w+/IN|\w+/TO) \w+/VB \w+/NN)");

            var matchEvent5 = matchexprEvent5.Matches(Final_Output_Pos_Event5);
            string afterposEvent5 = "";
            foreach (var item in matchEvent5)
            {
                afterposEvent5 = item.ToString();
            }
            string[] arrEvent5 = afterposEvent5.Split(' ');
            string Event5 = "";
            foreach (string spt in arrEvent5)
            {
                var findslash = new Regex(@"/");
                var matchslash = findslash.Matches(spt);
                if (matchslash.Count != 0)
                {
                    Event5 += spt.Substring(0, spt.LastIndexOf("/")) + " ";
                }
                else
                {
                    Event5 += spt;
                }
            }



            string Final_Output_Pos_Event5_1 = afterposEvent5.ToString();

            var matchexprEvent5_1 = new Regex(@"(\w+/VBP (\w+/IN|\w+/TO) \w+/VB)");

            var matchEvent5_1 = matchexprEvent5_1.Matches(Final_Output_Pos_Event5_1);
            string afterposEvent5_1 = "";
            foreach (var item in matchEvent5_1)
            {
                afterposEvent5_1 = item.ToString();
            }
            string[] arrEvent5_1 = afterposEvent5_1.Split(' ');
            string Event5_1 = "";
            foreach (string sptEvent5_1 in arrEvent5_1)
            {
                var findslashEvent5_1 = new Regex(@"/");
                var matchslashEvent5_1 = findslashEvent5_1.Matches(sptEvent5_1);
                if (matchslashEvent5_1.Count != 0)
                {
                    Event5_1 += sptEvent5_1.Substring(0, sptEvent5_1.LastIndexOf("/")) + " ";
                }
                else
                {
                    Event5_1 += sptEvent5_1;
                }
            }


            string Final_Output_Pos_Event6 = output.ToString();

            var matchexprEvent6 = new Regex(@"(\w+/VBG \w+/DT \w+/NN)");

            var matchEvent6 = matchexprEvent6.Matches(Final_Output_Pos_Event6);
            string afterposEvent6 = "";
            foreach (var item in matchEvent6)
            {
                afterposEvent6 = item.ToString();
            }
            string[] arrEvent6 = afterposEvent6.Split(' ');
            string Event6 = "";
            foreach (string spt in arrEvent5)
            {
                var findslash = new Regex(@"/");
                var matchslash = findslash.Matches(spt);
                if (matchslash.Count != 0)
                {
                    Event6 += spt.Substring(0, spt.LastIndexOf("/")) + " ";
                }
                else
                {
                    Event6 += spt;
                }
            }



            string Final_Output_Pos_Event6_1 = afterposEvent6.ToString();

            var matchexprEvent6_1 = new Regex(@"(\w+/VBG)");

            var matchEvent6_1 = matchexprEvent6_1.Matches(Final_Output_Pos_Event6_1);
            string afterposEvent6_1 = "";
            foreach (var item in matchEvent6_1)
            {
                afterposEvent6_1 = item.ToString();
            }
            string[] arrEvent6_1 = afterposEvent6_1.Split(' ');
            string Event6_1 = "";
            foreach (string sptEvent6_1 in arrEvent6_1)
            {
                var findslashEvent6_1 = new Regex(@"/");
                var matchslashEvent6_1 = findslashEvent6_1.Matches(sptEvent6_1);
                if (matchslashEvent6_1.Count != 0)
                {
                    Event6_1 += sptEvent6_1.Substring(0, sptEvent6_1.LastIndexOf("/")) + " ";
                }
                else
                {
                    Event6_1 += sptEvent6_1;
                }
            }



            if (Event1_1 != "")
            {
                navigation1 = "True";
            }
            else
            {
                navigation1 = "True";
            }


            if (Event2_1 != "")
            {
                navigation2 = "True";
            }
            else
            {
                navigation2 = "True";
            }

            if (Event3_1 != "")
            {
                navigation3 = "True";
            }
            else
            {
                navigation3 = "True";
            }

            if (Event4_1 != "")
            {
                navigation4 = "True";
            }
            else
            {
                navigation4 = "True";
            }

            if (Event5_1 != "")
            {
                navigation5 = "True";
            }
            else
            {
                navigation5 = "True";
            }



            SqlCommand CmdEvent = new SqlCommand("INSERT INTO table_Events (strRequirement,strEvent1,strEvent2,strEvent3,strEvent4,strEvent5,strEvent1_1,strEvent2_1,strEvent3_1,strEvent4_1,strEvent5_1,strEvent6,navigation1,navigation2,navigation3,navigation4,navigation5) Values ('" + sentence1 + "' ,'" + Event1 + "' ,'" + Event2 + "' ,'" + Event3 + "' ,'" + Event4 + "' ,'" + Event5 + "','" + Event1_1 + "' ,'" + Event2_1 + "' ,'" + Event3_1 + "' ,'" + Event4_1 + "' ,'" + Event5_1 + "' ,'" + Event6_1 + "','" + navigation1 + "' ,'" + navigation2 + "' ,'" + navigation3 + "' ,'" + navigation4 + "' ,'" + navigation5 + "')", aConnection);
            CmdEvent.ExecuteNonQuery();



            string Final_Output_Pos_Action1 = output.ToString();

            var matchexprAction1 = new Regex(@"(\w+/VBN \w+/VBG (\w+/JJ|\w+/NN) \w+/NN)");

            var matchAction1 = matchexprAction1.Matches(Final_Output_Pos_Action1);
            string afterposAction1 = "";
            foreach (var item in matchAction1)
            {
                afterposAction1 = item.ToString();
            }
            string[] arrAction1 = afterposAction1.Split(' ');
            string Action1 = "";
            foreach (string spt in arrAction1)
            {
                var findslash = new Regex(@"/");
                var matchslash = findslash.Matches(spt);
                if (matchslash.Count != 0)
                {
                    Action1 += spt.Substring(0, spt.LastIndexOf("/")) + " ";
                }
                else
                {
                    Action1 += spt;
                }
            }




            string Final_Output_Pos_Action1_1 = afterposAction1.ToString();

            var matchexprAction1_1 = new Regex(@"(\w+/VBN)");

            var matchAction1_1 = matchexprAction1_1.Matches(Final_Output_Pos_Action1_1);
            string afterposAction1_1 = "";
            foreach (var item in matchAction1_1)
            {
                afterposAction1_1 = item.ToString();
            }
            string[] arrAction1_1 = afterposAction1_1.Split(' ');
            string Action1_1 = "";
            foreach (string sptAction1_1 in arrAction1_1)
            {
                var findslashAction1_1 = new Regex(@"/");
                var matchslashAction1_1 = findslashAction1_1.Matches(sptAction1_1);
                if (matchslashAction1_1.Count != 0)
                {
                    Action1_1 += sptAction1_1.Substring(0, sptAction1_1.LastIndexOf("/")) + " ";
                }
                else
                {
                    Action1_1 += sptAction1_1;
                }
            }





            string Final_Output_Pos_Action2 = output.ToString();

            var matchexprAction2 = new Regex(@"(\w+/VB ((\w+/NN|\w+/PRP) )?(\w+/IN|\w+/VBG) (\w+/DT )?(\w+/NN) (\w+/NN))");

            var matchAction2 = matchexprAction2.Matches(Final_Output_Pos_Action2);
            string afterposAction2 = "";
            foreach (var item in matchAction2)
            {
                afterposAction2 = item.ToString();
            }
            string[] arrAction2 = afterposAction2.Split(' ');
            string Action2 = "";
            foreach (string spt in arrAction2)
            {
                var findslash = new Regex(@"/");
                var matchslash = findslash.Matches(spt);
                if (matchslash.Count != 0)
                {
                    Action2 += spt.Substring(0, spt.LastIndexOf("/")) + " ";
                }
                else
                {
                    Action2 += spt;
                }
            }





            string Final_Output_Pos_Action2_1 = afterposAction2.ToString();

            var matchexprAction2_1 = new Regex(@"(\w+/VB )");

            var matchAction2_1 = matchexprAction2_1.Matches(Final_Output_Pos_Action2_1);
            string afterposAction2_1 = "";
            foreach (var item in matchAction2_1)
            {
                afterposAction2_1 = item.ToString();
            }
            string[] arrAction2_1 = afterposAction2_1.Split(' ');
            string Action2_1 = "";
            foreach (string sptAction2_1 in arrAction2_1)
            {
                var findslashAction2_1 = new Regex(@"/");
                var matchslashAction2_1 = findslashAction2_1.Matches(sptAction2_1);
                if (matchslashAction2_1.Count != 0)
                {
                    Action2_1 += sptAction2_1.Substring(0, sptAction2_1.LastIndexOf("/")) + " ";
                }
                else
                {
                    Action2_1 += sptAction2_1;
                }
            }
            SqlCommand CmdAction = new SqlCommand("INSERT INTO table_Actions (strRequirement,strAction1,strAction2,strAction1_1,strAction2_1) Values ('" + sentence1 + "' ,'" + Action1 + "' ,'" + Action2 + "','" + Action1_1 + "' ,'" + Action2_1 + "' )", aConnection);
            CmdAction.ExecuteNonQuery();

















        }



















        aConnection.Close();
    }

    #region NLP methods

    private string[] SplitSentences(string paragraph)
    {
        if (mSentenceDetector == null)
        {
            mSentenceDetector = new OpenNLP.Tools.SentenceDetect.EnglishMaximumEntropySentenceDetector(mModelPath + "EnglishSD.nbin");
        }

        return mSentenceDetector.SentenceDetect(paragraph);
    }

    private string[] TokenizeSentence(string sentence)
    {
        if (mTokenizer == null)
        {
            mTokenizer = new OpenNLP.Tools.Tokenize.EnglishMaximumEntropyTokenizer(mModelPath + "EnglishTok.nbin");
        }

        return mTokenizer.Tokenize(sentence);
    }

    private string[] PosTagTokens(string[] tokens)
    {
        if (mPosTagger == null)
        {
            mPosTagger = new OpenNLP.Tools.PosTagger.EnglishMaximumEntropyPosTagger(mModelPath + "EnglishPOS.nbin", mModelPath + @"\Parser\tagdict");
        }

        return mPosTagger.Tag(tokens);
    }

    private OpenNLP.Tools.Parser.Parse ParseSentence(string sentence)
    {
        if (mParser == null)
        {
            mParser = new OpenNLP.Tools.Parser.EnglishTreebankParser(mModelPath, true, false);
        }

        OpenNLP.Tools.Parser.Parse obj_parser = mParser.DoParse(sentence);
        string Tree_Text = obj_parser.Show().ToString();
        //Label1.Text = Tree_Text;
        return mParser.DoParse(sentence);
    }

    private string FindNames(string sentence)
    {
        if (mNameFinder == null)
        {
            mNameFinder = new OpenNLP.Tools.NameFind.EnglishNameFinder(mModelPath + "namefind\\");
        }

        string[] models = new string[] { "date", "location", "money", "organization", "percentage", "person", "time" };
        return mNameFinder.GetNames(models, sentence);
    }
    #endregion


    

    public string getConnectionString()
    {
        try
        {
            string sConnection = "";//Data Source=MUHAMMAD;Initial Catalog=IIUI;User ID=sa;Password=tiger";

            // Get the mapped configuration file.
            System.Configuration.ConnectionStringSettingsCollection ConnSettings = ConfigurationManager.ConnectionStrings;
            sConnection = ConnSettings["con"].ToString();

            // Find the Sample code below to read the other sections of the Config File
            // For Reading Other Sections of the Configuration File
            // string PortNumber = ConfigurationManager.AppSettings.Get("PortNumber");
            // MessageBox.Show(PortNumber);            

            return sConnection;

        }
        catch (Exception err)
        {
            // Response.Write(err.Message);
            return "";
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }
    protected void brnres_Click(object sender, EventArgs e)
    {
        SqlConnection aConnection = new SqlConnection(getConnectionString());
        aConnection.Open();

        POS_Token_Split_Sentence();

        SqlCommand Cmd1 = new SqlCommand("truncate table table_Results", aConnection);
        Cmd1.ExecuteNonQuery();

        string container1, container2, container3, container4, container5, container6, component, foundevent, foundaction;

        //string ncontainer1, ncontainer2, ncontainer3, ncontainer4, ncontainer5, ncontainer6;

        SqlCommand Cmdcont = new SqlCommand("select * from  table_ViewContainers", aConnection);
        Cmdcont.ExecuteNonQuery();
        DataTable dtcontainerscount = new DataTable();
        using (SqlDataAdapter a = new SqlDataAdapter(Cmdcont))
        {
            a.Fill(dtcontainerscount);
        }



        for (int i = 1; i <= dtcontainerscount.Rows.Count; i++)
        {
            SqlCommand getcontainer = new SqlCommand("select * from table_ViewContainers where intId = '" + i + "'", aConnection);

            DataTable dtcontainers = new DataTable();
            using (SqlDataAdapter a = new SqlDataAdapter(getcontainer))
            {
                a.Fill(dtcontainers);
            }


            if (dtcontainers != null && dtcontainers.Rows.Count > 0)
            {

                container1 = dtcontainers.Rows[0]["strViewContainer1_1"].ToString();
                container2 = dtcontainers.Rows[0]["strViewContainer2_1"].ToString();
                container4 = dtcontainers.Rows[0]["strViewContainer4_1"].ToString();
                container3 = dtcontainers.Rows[0]["strViewContainer3_1"].ToString();

                container5 = dtcontainers.Rows[0]["strViewContainer55_1"].ToString();
                container6 = dtcontainers.Rows[0]["strViewContainer6_1"].ToString();

                if (container1 != "" && container3 != "")
                {
                    SqlCommand Cmdcontainers = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'" + container1 + "' ,'','' ,'','' ,'')", aConnection);
                    Cmdcontainers.ExecuteNonQuery();

                    Cmdcontainers = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'" + container3 + "' ,'','' ,'','' ,'')", aConnection);
                    Cmdcontainers.ExecuteNonQuery();

                    continue;
                }
                else if (container3 != "" && container6 != "")
                {
                    SqlCommand Cmdcontainers = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'" + container3 + "' ,'','' ,'','','' )", aConnection);
                    Cmdcontainers.ExecuteNonQuery();

                    Cmdcontainers = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'" + container6 + "' ,'','' ,'','','' )", aConnection);
                    Cmdcontainers.ExecuteNonQuery();

                    continue;
                }
                else
                {
                    if (container1 != "")
                    {
                        SqlCommand Cmdcontainers = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'" + container1 + "' ,'','' ,'','','' )", aConnection);
                        Cmdcontainers.ExecuteNonQuery();







                        #region component

                        for (int componentloop = i; componentloop <= dtcontainerscount.Rows.Count; componentloop++)
                        {
                            SqlCommand getcomponent = new SqlCommand("select * from table_ViewComponent where intId = '" + componentloop + "'", aConnection);

                            DataTable dtcomponent = new DataTable();
                            using (SqlDataAdapter a = new SqlDataAdapter(getcomponent))
                            {
                                a.Fill(dtcomponent);
                            }
                            if (dtcomponent != null && dtcomponent.Rows.Count > 0)
                            {
                                component = dtcomponent.Rows[0]["strViewComponent1_1"].ToString();
                                if (component != "")
                                {
                                    SqlCommand Cmdcomponent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'" + component + "','' ,'','','' )", aConnection);
                                    Cmdcomponent.ExecuteNonQuery();

                                    #region events
                                    for (int eventloop = i; eventloop <= dtcontainerscount.Rows.Count; eventloop++)
                                    {

                                        SqlCommand getevent = new SqlCommand("select * from table_Events where intId = '" + eventloop + "'", aConnection);

                                        DataTable dtevent = new DataTable();
                                        using (SqlDataAdapter a = new SqlDataAdapter(getevent))
                                        {
                                            a.Fill(dtevent);
                                        }


                                        if (dtevent != null && dtevent.Rows.Count > 0)
                                        {
                                            foundevent = dtevent.Rows[0]["strEvent1_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation1"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }










                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent2_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation2"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent3_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation3"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent4_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation4"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }






                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent5_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }







                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }








                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }
                                            foundevent = "";
                                        }

                                    }
                                    #endregion


                                    break;
                                }


                                component = "";
                                component = dtcomponent.Rows[0]["strViewComponent2_1"].ToString();
                                if (component != "")
                                {
                                    SqlCommand Cmdcomponent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'" + component + "','' ,'','','' )", aConnection);
                                    Cmdcomponent.ExecuteNonQuery();

                                    #region events
                                    for (int eventloop = i; eventloop <= dtcontainerscount.Rows.Count; eventloop++)
                                    {

                                        SqlCommand getevent = new SqlCommand("select * from table_Events where intId = '" + eventloop + "'", aConnection);

                                        DataTable dtevent = new DataTable();
                                        using (SqlDataAdapter a = new SqlDataAdapter(getevent))
                                        {
                                            a.Fill(dtevent);
                                        }


                                        if (dtevent != null && dtevent.Rows.Count > 0)
                                        {
                                            foundevent = dtevent.Rows[0]["strEvent1_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation1"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }










                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent2_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation2"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent3_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation3"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent4_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation4"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }






                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent5_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }







                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }








                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }
                                            foundevent = "";
                                        }

                                    }
                                    #endregion
                                    break;
                                }

                                component = "";
                                component = dtcomponent.Rows[0]["strViewComponent3_1"].ToString();
                                if (component != "")
                                {
                                    SqlCommand Cmdcomponent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'" + component + "','' ,'','','' )", aConnection);
                                    Cmdcomponent.ExecuteNonQuery();

                                    #region events
                                    for (int eventloop = i; eventloop <= dtcontainerscount.Rows.Count; eventloop++)
                                    {

                                        SqlCommand getevent = new SqlCommand("select * from table_Events where intId = '" + eventloop + "'", aConnection);

                                        DataTable dtevent = new DataTable();
                                        using (SqlDataAdapter a = new SqlDataAdapter(getevent))
                                        {
                                            a.Fill(dtevent);
                                        }


                                        if (dtevent != null && dtevent.Rows.Count > 0)
                                        {
                                            foundevent = dtevent.Rows[0]["strEvent1_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation1"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }










                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent2_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation2"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent3_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation3"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent4_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation4"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }






                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent5_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }







                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }








                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }
                                            foundevent = "";
                                        }

                                    }
                                    #endregion
                                    break;
                                }

                                component = "";


                                component = dtcomponent.Rows[0]["strViewComponent4_1"].ToString();
                                if (component != "")
                                {
                                    SqlCommand Cmdcomponent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'" + component + "','' ,'' ,'','')", aConnection);
                                    Cmdcomponent.ExecuteNonQuery();


                                    #region events
                                    for (int eventloop = i; eventloop <= dtcontainerscount.Rows.Count; eventloop++)
                                    {

                                        SqlCommand getevent = new SqlCommand("select * from table_Events where intId = '" + eventloop + "'", aConnection);

                                        DataTable dtevent = new DataTable();
                                        using (SqlDataAdapter a = new SqlDataAdapter(getevent))
                                        {
                                            a.Fill(dtevent);
                                        }


                                        if (dtevent != null && dtevent.Rows.Count > 0)
                                        {
                                            foundevent = dtevent.Rows[0]["strEvent1_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation1"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }










                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent2_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation2"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent3_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation3"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent4_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation4"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }






                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent5_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }







                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }








                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }
                                            foundevent = "";
                                        }

                                    }
                                    #endregion
                                    break;
                                }


                                component = "";
                                component = dtcomponent.Rows[0]["strViewComponent5_1"].ToString();
                                if (component != "")
                                {
                                    SqlCommand Cmdcomponent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'" + component + "','' ,'' ,'','')", aConnection);
                                    Cmdcomponent.ExecuteNonQuery();


                                    #region events
                                    for (int eventloop = i; eventloop <= dtcontainerscount.Rows.Count; eventloop++)
                                    {

                                        SqlCommand getevent = new SqlCommand("select * from table_Events where intId = '" + eventloop + "'", aConnection);

                                        DataTable dtevent = new DataTable();
                                        using (SqlDataAdapter a = new SqlDataAdapter(getevent))
                                        {
                                            a.Fill(dtevent);
                                        }


                                        if (dtevent != null && dtevent.Rows.Count > 0)
                                        {
                                            foundevent = dtevent.Rows[0]["strEvent1_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation1"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }










                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent2_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation2"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent3_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation3"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent4_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation4"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }






                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent5_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }







                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }








                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }
                                            foundevent = "";
                                        }

                                    }
                                    #endregion
                                    break;
                                }


                                component = "";
                                component = dtcomponent.Rows[0]["strViewComponent6_1"].ToString();
                                if (component != "")
                                {
                                    SqlCommand Cmdcomponent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'" + component + "','' ,'','' ,'')", aConnection);
                                    Cmdcomponent.ExecuteNonQuery();


                                    #region events
                                    for (int eventloop = i; eventloop <= dtcontainerscount.Rows.Count; eventloop++)
                                    {

                                        SqlCommand getevent = new SqlCommand("select * from table_Events where intId = '" + eventloop + "'", aConnection);

                                        DataTable dtevent = new DataTable();
                                        using (SqlDataAdapter a = new SqlDataAdapter(getevent))
                                        {
                                            a.Fill(dtevent);
                                        }


                                        if (dtevent != null && dtevent.Rows.Count > 0)
                                        {
                                            foundevent = dtevent.Rows[0]["strEvent1_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation1"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }










                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent2_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation2"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent3_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation3"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent4_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation4"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }






                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent5_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }







                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }








                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }
                                            foundevent = "";
                                        }

                                    }
                                    #endregion
                                    break;
                                }
                                component = "";
                            }
                        }
                        #endregion
                    }





                    if (container2 != "")
                    {
                        SqlCommand Cmdcontainers = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'" + container2 + "' ,'','' ,'','','' )", aConnection);
                        Cmdcontainers.ExecuteNonQuery();





                        #region component

                        for (int componentloop = i; componentloop <= dtcontainerscount.Rows.Count; componentloop++)
                        {
                            SqlCommand getcomponent = new SqlCommand("select * from table_ViewComponent where intId = '" + componentloop + "'", aConnection);

                            DataTable dtcomponent = new DataTable();
                            using (SqlDataAdapter a = new SqlDataAdapter(getcomponent))
                            {
                                a.Fill(dtcomponent);
                            }
                            if (dtcomponent != null && dtcomponent.Rows.Count > 0)
                            {
                                component = dtcomponent.Rows[0]["strViewComponent1_1"].ToString();
                                if (component != "")
                                {
                                    SqlCommand Cmdcomponent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'" + component + "','' ,'','','' )", aConnection);
                                    Cmdcomponent.ExecuteNonQuery();

                                    #region events
                                    for (int eventloop = i; eventloop <= dtcontainerscount.Rows.Count; eventloop++)
                                    {

                                        SqlCommand getevent = new SqlCommand("select * from table_Events where intId = '" + eventloop + "'", aConnection);

                                        DataTable dtevent = new DataTable();
                                        using (SqlDataAdapter a = new SqlDataAdapter(getevent))
                                        {
                                            a.Fill(dtevent);
                                        }


                                        if (dtevent != null && dtevent.Rows.Count > 0)
                                        {
                                            foundevent = dtevent.Rows[0]["strEvent1_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation1"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }










                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent2_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation2"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent3_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation3"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent4_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation4"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }






                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent5_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }







                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }








                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }
                                            foundevent = "";
                                        }

                                    }
                                    #endregion


                                    break;
                                }


                                component = "";
                                component = dtcomponent.Rows[0]["strViewComponent2_1"].ToString();
                                if (component != "")
                                {
                                    SqlCommand Cmdcomponent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'" + component + "','' ,'','','' )", aConnection);
                                    Cmdcomponent.ExecuteNonQuery();

                                    #region events
                                    for (int eventloop = i; eventloop <= dtcontainerscount.Rows.Count; eventloop++)
                                    {

                                        SqlCommand getevent = new SqlCommand("select * from table_Events where intId = '" + eventloop + "'", aConnection);

                                        DataTable dtevent = new DataTable();
                                        using (SqlDataAdapter a = new SqlDataAdapter(getevent))
                                        {
                                            a.Fill(dtevent);
                                        }


                                        if (dtevent != null && dtevent.Rows.Count > 0)
                                        {
                                            foundevent = dtevent.Rows[0]["strEvent1_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation1"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }










                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent2_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation2"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent3_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation3"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent4_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation4"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }






                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent5_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }







                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }








                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }
                                            foundevent = "";
                                        }

                                    }
                                    #endregion
                                    break;
                                }

                                component = "";
                                component = dtcomponent.Rows[0]["strViewComponent3_1"].ToString();
                                if (component != "")
                                {
                                    SqlCommand Cmdcomponent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'" + component + "','' ,'','','' )", aConnection);
                                    Cmdcomponent.ExecuteNonQuery();

                                    #region events
                                    for (int eventloop = i; eventloop <= dtcontainerscount.Rows.Count; eventloop++)
                                    {

                                        SqlCommand getevent = new SqlCommand("select * from table_Events where intId = '" + eventloop + "'", aConnection);

                                        DataTable dtevent = new DataTable();
                                        using (SqlDataAdapter a = new SqlDataAdapter(getevent))
                                        {
                                            a.Fill(dtevent);
                                        }


                                        if (dtevent != null && dtevent.Rows.Count > 0)
                                        {
                                            foundevent = dtevent.Rows[0]["strEvent1_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation1"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }










                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent2_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation2"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent3_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation3"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent4_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation4"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }






                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent5_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }







                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }








                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }
                                            foundevent = "";
                                        }

                                    }
                                    #endregion
                                    break;
                                }

                                component = "";


                                component = dtcomponent.Rows[0]["strViewComponent4_1"].ToString();
                                if (component != "")
                                {
                                    SqlCommand Cmdcomponent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'" + component + "','' ,'' ,'','')", aConnection);
                                    Cmdcomponent.ExecuteNonQuery();


                                    #region events
                                    for (int eventloop = i; eventloop <= dtcontainerscount.Rows.Count; eventloop++)
                                    {

                                        SqlCommand getevent = new SqlCommand("select * from table_Events where intId = '" + eventloop + "'", aConnection);

                                        DataTable dtevent = new DataTable();
                                        using (SqlDataAdapter a = new SqlDataAdapter(getevent))
                                        {
                                            a.Fill(dtevent);
                                        }


                                        if (dtevent != null && dtevent.Rows.Count > 0)
                                        {
                                            foundevent = dtevent.Rows[0]["strEvent1_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation1"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }










                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent2_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation2"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent3_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation3"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent4_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation4"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }






                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent5_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }







                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }








                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }
                                            foundevent = "";
                                        }

                                    }
                                    #endregion
                                    break;
                                }


                                component = "";
                                component = dtcomponent.Rows[0]["strViewComponent5_1"].ToString();
                                if (component != "")
                                {
                                    SqlCommand Cmdcomponent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'" + component + "','' ,'' ,'','')", aConnection);
                                    Cmdcomponent.ExecuteNonQuery();


                                    #region events
                                    for (int eventloop = i; eventloop <= dtcontainerscount.Rows.Count; eventloop++)
                                    {

                                        SqlCommand getevent = new SqlCommand("select * from table_Events where intId = '" + eventloop + "'", aConnection);

                                        DataTable dtevent = new DataTable();
                                        using (SqlDataAdapter a = new SqlDataAdapter(getevent))
                                        {
                                            a.Fill(dtevent);
                                        }


                                        if (dtevent != null && dtevent.Rows.Count > 0)
                                        {
                                            foundevent = dtevent.Rows[0]["strEvent1_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation1"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }










                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent2_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation2"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent3_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation3"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent4_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation4"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }






                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent5_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }







                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }








                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }
                                            foundevent = "";
                                        }

                                    }
                                    #endregion
                                    break;
                                }


                                component = "";
                                component = dtcomponent.Rows[0]["strViewComponent6_1"].ToString();
                                if (component != "")
                                {
                                    SqlCommand Cmdcomponent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'" + component + "','' ,'','' ,'')", aConnection);
                                    Cmdcomponent.ExecuteNonQuery();


                                    #region events
                                    for (int eventloop = i; eventloop <= dtcontainerscount.Rows.Count; eventloop++)
                                    {

                                        SqlCommand getevent = new SqlCommand("select * from table_Events where intId = '" + eventloop + "'", aConnection);

                                        DataTable dtevent = new DataTable();
                                        using (SqlDataAdapter a = new SqlDataAdapter(getevent))
                                        {
                                            a.Fill(dtevent);
                                        }


                                        if (dtevent != null && dtevent.Rows.Count > 0)
                                        {
                                            foundevent = dtevent.Rows[0]["strEvent1_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation1"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }










                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent2_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation2"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent3_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation3"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent4_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation4"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }






                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent5_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }







                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }








                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }
                                            foundevent = "";
                                        }

                                    }
                                    #endregion
                                    break;
                                }
                                component = "";
                            }
                        }
                        #endregion
                    }





                    if (container3 != "")
                    {
                        SqlCommand Cmdcontainers = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'" + container3 + "' ,'','' ,'' ,'','')", aConnection);
                        Cmdcontainers.ExecuteNonQuery();





                        #region component

                        for (int componentloop = i; componentloop <= dtcontainerscount.Rows.Count; componentloop++)
                        {
                            SqlCommand getcomponent = new SqlCommand("select * from table_ViewComponent where intId = '" + componentloop + "'", aConnection);

                            DataTable dtcomponent = new DataTable();
                            using (SqlDataAdapter a = new SqlDataAdapter(getcomponent))
                            {
                                a.Fill(dtcomponent);
                            }
                            if (dtcomponent != null && dtcomponent.Rows.Count > 0)
                            {
                                component = dtcomponent.Rows[0]["strViewComponent1_1"].ToString();
                                if (component != "")
                                {
                                    SqlCommand Cmdcomponent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'" + component + "','' ,'','','' )", aConnection);
                                    Cmdcomponent.ExecuteNonQuery();

                                    #region events
                                    for (int eventloop = i; eventloop <= dtcontainerscount.Rows.Count; eventloop++)
                                    {

                                        SqlCommand getevent = new SqlCommand("select * from table_Events where intId = '" + eventloop + "'", aConnection);

                                        DataTable dtevent = new DataTable();
                                        using (SqlDataAdapter a = new SqlDataAdapter(getevent))
                                        {
                                            a.Fill(dtevent);
                                        }


                                        if (dtevent != null && dtevent.Rows.Count > 0)
                                        {
                                            foundevent = dtevent.Rows[0]["strEvent1_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation1"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }










                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent2_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation2"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent3_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation3"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent4_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation4"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }






                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent5_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }







                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }








                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }
                                            foundevent = "";
                                        }

                                    }
                                    #endregion


                                    break;
                                }


                                component = "";
                                component = dtcomponent.Rows[0]["strViewComponent2_1"].ToString();
                                if (component != "")
                                {
                                    SqlCommand Cmdcomponent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'" + component + "','' ,'','','' )", aConnection);
                                    Cmdcomponent.ExecuteNonQuery();

                                    #region events
                                    for (int eventloop = i; eventloop <= dtcontainerscount.Rows.Count; eventloop++)
                                    {

                                        SqlCommand getevent = new SqlCommand("select * from table_Events where intId = '" + eventloop + "'", aConnection);

                                        DataTable dtevent = new DataTable();
                                        using (SqlDataAdapter a = new SqlDataAdapter(getevent))
                                        {
                                            a.Fill(dtevent);
                                        }


                                        if (dtevent != null && dtevent.Rows.Count > 0)
                                        {
                                            foundevent = dtevent.Rows[0]["strEvent1_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation1"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }










                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent2_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation2"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent3_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation3"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent4_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation4"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }






                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent5_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }







                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }








                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }
                                            foundevent = "";
                                        }

                                    }
                                    #endregion
                                    break;
                                }

                                component = "";
                                component = dtcomponent.Rows[0]["strViewComponent3_1"].ToString();
                                if (component != "")
                                {
                                    SqlCommand Cmdcomponent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'" + component + "','' ,'','','' )", aConnection);
                                    Cmdcomponent.ExecuteNonQuery();

                                    #region events
                                    for (int eventloop = i; eventloop <= dtcontainerscount.Rows.Count; eventloop++)
                                    {

                                        SqlCommand getevent = new SqlCommand("select * from table_Events where intId = '" + eventloop + "'", aConnection);

                                        DataTable dtevent = new DataTable();
                                        using (SqlDataAdapter a = new SqlDataAdapter(getevent))
                                        {
                                            a.Fill(dtevent);
                                        }


                                        if (dtevent != null && dtevent.Rows.Count > 0)
                                        {
                                            foundevent = dtevent.Rows[0]["strEvent1_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation1"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }










                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent2_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation2"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent3_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation3"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent4_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation4"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }






                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent5_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }







                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }








                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }
                                            foundevent = "";
                                        }

                                    }
                                    #endregion
                                    break;
                                }

                                component = "";


                                component = dtcomponent.Rows[0]["strViewComponent4_1"].ToString();
                                if (component != "")
                                {
                                    SqlCommand Cmdcomponent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'" + component + "','' ,'' ,'','')", aConnection);
                                    Cmdcomponent.ExecuteNonQuery();


                                    #region events
                                    for (int eventloop = i; eventloop <= dtcontainerscount.Rows.Count; eventloop++)
                                    {

                                        SqlCommand getevent = new SqlCommand("select * from table_Events where intId = '" + eventloop + "'", aConnection);

                                        DataTable dtevent = new DataTable();
                                        using (SqlDataAdapter a = new SqlDataAdapter(getevent))
                                        {
                                            a.Fill(dtevent);
                                        }


                                        if (dtevent != null && dtevent.Rows.Count > 0)
                                        {
                                            foundevent = dtevent.Rows[0]["strEvent1_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation1"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }










                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent2_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation2"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent3_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation3"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent4_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation4"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }






                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent5_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }







                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }








                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }
                                            foundevent = "";
                                        }

                                    }
                                    #endregion
                                    break;
                                }


                                component = "";
                                component = dtcomponent.Rows[0]["strViewComponent5_1"].ToString();
                                if (component != "")
                                {
                                    SqlCommand Cmdcomponent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'" + component + "','' ,'' ,'','')", aConnection);
                                    Cmdcomponent.ExecuteNonQuery();


                                    #region events
                                    for (int eventloop = i; eventloop <= dtcontainerscount.Rows.Count; eventloop++)
                                    {

                                        SqlCommand getevent = new SqlCommand("select * from table_Events where intId = '" + eventloop + "'", aConnection);

                                        DataTable dtevent = new DataTable();
                                        using (SqlDataAdapter a = new SqlDataAdapter(getevent))
                                        {
                                            a.Fill(dtevent);
                                        }


                                        if (dtevent != null && dtevent.Rows.Count > 0)
                                        {
                                            foundevent = dtevent.Rows[0]["strEvent1_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation1"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }










                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent2_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation2"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent3_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation3"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent4_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation4"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }






                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent5_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }







                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }








                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }
                                            foundevent = "";
                                        }

                                    }
                                    #endregion
                                    break;
                                }


                                component = "";
                                component = dtcomponent.Rows[0]["strViewComponent6_1"].ToString();
                                if (component != "")
                                {
                                    SqlCommand Cmdcomponent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'" + component + "','' ,'','' ,'')", aConnection);
                                    Cmdcomponent.ExecuteNonQuery();


                                    #region events
                                    for (int eventloop = i; eventloop <= dtcontainerscount.Rows.Count; eventloop++)
                                    {

                                        SqlCommand getevent = new SqlCommand("select * from table_Events where intId = '" + eventloop + "'", aConnection);

                                        DataTable dtevent = new DataTable();
                                        using (SqlDataAdapter a = new SqlDataAdapter(getevent))
                                        {
                                            a.Fill(dtevent);
                                        }


                                        if (dtevent != null && dtevent.Rows.Count > 0)
                                        {
                                            foundevent = dtevent.Rows[0]["strEvent1_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation1"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }










                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent2_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation2"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent3_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation3"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent4_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation4"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }






                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent5_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }







                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }








                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }
                                            foundevent = "";
                                        }

                                    }
                                    #endregion
                                    break;
                                }
                                component = "";
                            }
                        }
                        #endregion
                    }






                    if (container4 != "")
                    {
                        SqlCommand Cmdcontainers = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'" + container4 + "' ,'','' ,'' ,'','')", aConnection);
                        Cmdcontainers.ExecuteNonQuery();





                        #region component

                        for (int componentloop = i; componentloop <= dtcontainerscount.Rows.Count; componentloop++)
                        {
                            SqlCommand getcomponent = new SqlCommand("select * from table_ViewComponent where intId = '" + componentloop + "'", aConnection);

                            DataTable dtcomponent = new DataTable();
                            using (SqlDataAdapter a = new SqlDataAdapter(getcomponent))
                            {
                                a.Fill(dtcomponent);
                            }
                            if (dtcomponent != null && dtcomponent.Rows.Count > 0)
                            {
                                component = dtcomponent.Rows[0]["strViewComponent1_1"].ToString();
                                if (component != "")
                                {
                                    SqlCommand Cmdcomponent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'" + component + "','' ,'','','' )", aConnection);
                                    Cmdcomponent.ExecuteNonQuery();

                                    #region events
                                    for (int eventloop = i; eventloop <= dtcontainerscount.Rows.Count; eventloop++)
                                    {

                                        SqlCommand getevent = new SqlCommand("select * from table_Events where intId = '" + eventloop + "'", aConnection);

                                        DataTable dtevent = new DataTable();
                                        using (SqlDataAdapter a = new SqlDataAdapter(getevent))
                                        {
                                            a.Fill(dtevent);
                                        }


                                        if (dtevent != null && dtevent.Rows.Count > 0)
                                        {
                                            foundevent = dtevent.Rows[0]["strEvent1_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation1"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }










                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent2_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation2"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent3_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation3"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent4_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation4"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }






                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent5_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }







                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }








                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }
                                            foundevent = "";
                                        }

                                    }
                                    #endregion


                                    break;
                                }


                                component = "";
                                component = dtcomponent.Rows[0]["strViewComponent2_1"].ToString();
                                if (component != "")
                                {
                                    SqlCommand Cmdcomponent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'" + component + "','' ,'','','' )", aConnection);
                                    Cmdcomponent.ExecuteNonQuery();

                                    #region events
                                    for (int eventloop = i; eventloop <= dtcontainerscount.Rows.Count; eventloop++)
                                    {

                                        SqlCommand getevent = new SqlCommand("select * from table_Events where intId = '" + eventloop + "'", aConnection);

                                        DataTable dtevent = new DataTable();
                                        using (SqlDataAdapter a = new SqlDataAdapter(getevent))
                                        {
                                            a.Fill(dtevent);
                                        }


                                        if (dtevent != null && dtevent.Rows.Count > 0)
                                        {
                                            foundevent = dtevent.Rows[0]["strEvent1_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation1"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }










                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent2_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation2"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent3_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation3"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent4_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation4"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }






                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent5_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }







                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }








                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }
                                            foundevent = "";
                                        }

                                    }
                                    #endregion
                                    break;
                                }

                                component = "";
                                component = dtcomponent.Rows[0]["strViewComponent3_1"].ToString();
                                if (component != "")
                                {
                                    SqlCommand Cmdcomponent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'" + component + "','' ,'','','' )", aConnection);
                                    Cmdcomponent.ExecuteNonQuery();

                                    #region events
                                    for (int eventloop = i; eventloop <= dtcontainerscount.Rows.Count; eventloop++)
                                    {

                                        SqlCommand getevent = new SqlCommand("select * from table_Events where intId = '" + eventloop + "'", aConnection);

                                        DataTable dtevent = new DataTable();
                                        using (SqlDataAdapter a = new SqlDataAdapter(getevent))
                                        {
                                            a.Fill(dtevent);
                                        }


                                        if (dtevent != null && dtevent.Rows.Count > 0)
                                        {
                                            foundevent = dtevent.Rows[0]["strEvent1_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation1"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }










                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent2_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation2"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent3_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation3"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent4_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation4"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }






                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent5_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }







                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }








                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }
                                            foundevent = "";
                                        }

                                    }
                                    #endregion
                                    break;
                                }

                                component = "";


                                component = dtcomponent.Rows[0]["strViewComponent4_1"].ToString();
                                if (component != "")
                                {
                                    SqlCommand Cmdcomponent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'" + component + "','' ,'' ,'','')", aConnection);
                                    Cmdcomponent.ExecuteNonQuery();


                                    #region events
                                    for (int eventloop = i; eventloop <= dtcontainerscount.Rows.Count; eventloop++)
                                    {

                                        SqlCommand getevent = new SqlCommand("select * from table_Events where intId = '" + eventloop + "'", aConnection);

                                        DataTable dtevent = new DataTable();
                                        using (SqlDataAdapter a = new SqlDataAdapter(getevent))
                                        {
                                            a.Fill(dtevent);
                                        }


                                        if (dtevent != null && dtevent.Rows.Count > 0)
                                        {
                                            foundevent = dtevent.Rows[0]["strEvent1_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation1"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }










                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent2_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation2"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent3_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation3"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent4_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation4"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }






                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent5_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }







                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }








                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }
                                            foundevent = "";
                                        }

                                    }
                                    #endregion
                                    break;
                                }


                                component = "";
                                component = dtcomponent.Rows[0]["strViewComponent5_1"].ToString();
                                if (component != "")
                                {
                                    SqlCommand Cmdcomponent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'" + component + "','' ,'' ,'','')", aConnection);
                                    Cmdcomponent.ExecuteNonQuery();


                                    #region events
                                    for (int eventloop = i; eventloop <= dtcontainerscount.Rows.Count; eventloop++)
                                    {

                                        SqlCommand getevent = new SqlCommand("select * from table_Events where intId = '" + eventloop + "'", aConnection);

                                        DataTable dtevent = new DataTable();
                                        using (SqlDataAdapter a = new SqlDataAdapter(getevent))
                                        {
                                            a.Fill(dtevent);
                                        }


                                        if (dtevent != null && dtevent.Rows.Count > 0)
                                        {
                                            foundevent = dtevent.Rows[0]["strEvent1_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation1"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }










                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent2_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation2"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent3_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation3"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent4_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation4"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }






                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent5_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }







                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }








                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }
                                            foundevent = "";
                                        }

                                    }
                                    #endregion
                                    break;
                                }


                                component = "";
                                component = dtcomponent.Rows[0]["strViewComponent6_1"].ToString();
                                if (component != "")
                                {
                                    SqlCommand Cmdcomponent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'" + component + "','' ,'','' ,'')", aConnection);
                                    Cmdcomponent.ExecuteNonQuery();


                                    #region events
                                    for (int eventloop = i; eventloop <= dtcontainerscount.Rows.Count; eventloop++)
                                    {

                                        SqlCommand getevent = new SqlCommand("select * from table_Events where intId = '" + eventloop + "'", aConnection);

                                        DataTable dtevent = new DataTable();
                                        using (SqlDataAdapter a = new SqlDataAdapter(getevent))
                                        {
                                            a.Fill(dtevent);
                                        }


                                        if (dtevent != null && dtevent.Rows.Count > 0)
                                        {
                                            foundevent = dtevent.Rows[0]["strEvent1_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation1"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }










                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent2_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation2"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent3_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation3"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent4_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation4"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }






                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent5_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }







                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }








                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }
                                            foundevent = "";
                                        }

                                    }
                                    #endregion
                                    break;
                                }
                                component = "";
                            }
                        }
                        #endregion

                    }



                    if (container5 != "")
                    {
                        SqlCommand Cmdcontainers = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'" + container5 + "' ,'','' ,'' ,'','')", aConnection);
                        Cmdcontainers.ExecuteNonQuery();




                        #region component

                        for (int componentloop = i; componentloop <= dtcontainerscount.Rows.Count; componentloop++)
                        {
                            SqlCommand getcomponent = new SqlCommand("select * from table_ViewComponent where intId = '" + componentloop + "'", aConnection);

                            DataTable dtcomponent = new DataTable();
                            using (SqlDataAdapter a = new SqlDataAdapter(getcomponent))
                            {
                                a.Fill(dtcomponent);
                            }
                            if (dtcomponent != null && dtcomponent.Rows.Count > 0)
                            {
                                component = dtcomponent.Rows[0]["strViewComponent1_1"].ToString();
                                if (component != "")
                                {
                                    SqlCommand Cmdcomponent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'" + component + "','' ,'','','' )", aConnection);
                                    Cmdcomponent.ExecuteNonQuery();

                                    #region events
                                    for (int eventloop = i; eventloop <= dtcontainerscount.Rows.Count; eventloop++)
                                    {

                                        SqlCommand getevent = new SqlCommand("select * from table_Events where intId = '" + eventloop + "'", aConnection);

                                        DataTable dtevent = new DataTable();
                                        using (SqlDataAdapter a = new SqlDataAdapter(getevent))
                                        {
                                            a.Fill(dtevent);
                                        }


                                        if (dtevent != null && dtevent.Rows.Count > 0)
                                        {
                                            foundevent = dtevent.Rows[0]["strEvent1_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation1"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }










                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent2_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation2"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent3_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation3"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent4_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation4"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }






                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent5_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }







                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }








                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }
                                            foundevent = "";
                                        }

                                    }
                                    #endregion


                                    break;
                                }


                                component = "";
                                component = dtcomponent.Rows[0]["strViewComponent2_1"].ToString();
                                if (component != "")
                                {
                                    SqlCommand Cmdcomponent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'" + component + "','' ,'','','' )", aConnection);
                                    Cmdcomponent.ExecuteNonQuery();

                                    #region events
                                    for (int eventloop = i; eventloop <= dtcontainerscount.Rows.Count; eventloop++)
                                    {

                                        SqlCommand getevent = new SqlCommand("select * from table_Events where intId = '" + eventloop + "'", aConnection);

                                        DataTable dtevent = new DataTable();
                                        using (SqlDataAdapter a = new SqlDataAdapter(getevent))
                                        {
                                            a.Fill(dtevent);
                                        }


                                        if (dtevent != null && dtevent.Rows.Count > 0)
                                        {
                                            foundevent = dtevent.Rows[0]["strEvent1_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation1"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }










                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent2_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation2"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent3_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation3"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent4_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation4"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }






                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent5_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }







                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }








                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }
                                            foundevent = "";
                                        }

                                    }
                                    #endregion
                                    break;
                                }

                                component = "";
                                component = dtcomponent.Rows[0]["strViewComponent3_1"].ToString();
                                if (component != "")
                                {
                                    SqlCommand Cmdcomponent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'" + component + "','' ,'','','' )", aConnection);
                                    Cmdcomponent.ExecuteNonQuery();

                                    #region events
                                    for (int eventloop = i; eventloop <= dtcontainerscount.Rows.Count; eventloop++)
                                    {

                                        SqlCommand getevent = new SqlCommand("select * from table_Events where intId = '" + eventloop + "'", aConnection);

                                        DataTable dtevent = new DataTable();
                                        using (SqlDataAdapter a = new SqlDataAdapter(getevent))
                                        {
                                            a.Fill(dtevent);
                                        }


                                        if (dtevent != null && dtevent.Rows.Count > 0)
                                        {
                                            foundevent = dtevent.Rows[0]["strEvent1_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation1"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }










                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent2_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation2"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent3_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation3"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent4_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation4"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }






                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent5_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }







                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }








                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }
                                            foundevent = "";
                                        }

                                    }
                                    #endregion
                                    break;
                                }

                                component = "";


                                component = dtcomponent.Rows[0]["strViewComponent4_1"].ToString();
                                if (component != "")
                                {
                                    SqlCommand Cmdcomponent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'" + component + "','' ,'' ,'','')", aConnection);
                                    Cmdcomponent.ExecuteNonQuery();


                                    #region events
                                    for (int eventloop = i; eventloop <= dtcontainerscount.Rows.Count; eventloop++)
                                    {

                                        SqlCommand getevent = new SqlCommand("select * from table_Events where intId = '" + eventloop + "'", aConnection);

                                        DataTable dtevent = new DataTable();
                                        using (SqlDataAdapter a = new SqlDataAdapter(getevent))
                                        {
                                            a.Fill(dtevent);
                                        }


                                        if (dtevent != null && dtevent.Rows.Count > 0)
                                        {
                                            foundevent = dtevent.Rows[0]["strEvent1_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation1"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }










                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent2_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation2"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent3_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation3"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent4_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation4"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }






                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent5_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }







                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }








                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }
                                            foundevent = "";
                                        }

                                    }
                                    #endregion
                                    break;
                                }


                                component = "";
                                component = dtcomponent.Rows[0]["strViewComponent5_1"].ToString();
                                if (component != "")
                                {
                                    SqlCommand Cmdcomponent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'" + component + "','' ,'' ,'','')", aConnection);
                                    Cmdcomponent.ExecuteNonQuery();


                                    #region events
                                    for (int eventloop = i; eventloop <= dtcontainerscount.Rows.Count; eventloop++)
                                    {

                                        SqlCommand getevent = new SqlCommand("select * from table_Events where intId = '" + eventloop + "'", aConnection);

                                        DataTable dtevent = new DataTable();
                                        using (SqlDataAdapter a = new SqlDataAdapter(getevent))
                                        {
                                            a.Fill(dtevent);
                                        }


                                        if (dtevent != null && dtevent.Rows.Count > 0)
                                        {
                                            foundevent = dtevent.Rows[0]["strEvent1_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation1"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }










                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent2_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation2"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent3_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation3"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent4_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation4"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }






                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent5_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }







                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }








                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }
                                            foundevent = "";
                                        }

                                    }
                                    #endregion
                                    break;
                                }


                                component = "";
                                component = dtcomponent.Rows[0]["strViewComponent6_1"].ToString();
                                if (component != "")
                                {
                                    SqlCommand Cmdcomponent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'" + component + "','' ,'','' ,'')", aConnection);
                                    Cmdcomponent.ExecuteNonQuery();


                                    #region events
                                    for (int eventloop = i; eventloop <= dtcontainerscount.Rows.Count; eventloop++)
                                    {

                                        SqlCommand getevent = new SqlCommand("select * from table_Events where intId = '" + eventloop + "'", aConnection);

                                        DataTable dtevent = new DataTable();
                                        using (SqlDataAdapter a = new SqlDataAdapter(getevent))
                                        {
                                            a.Fill(dtevent);
                                        }


                                        if (dtevent != null && dtevent.Rows.Count > 0)
                                        {
                                            foundevent = dtevent.Rows[0]["strEvent1_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation1"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }










                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent2_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation2"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent3_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation3"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent4_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation4"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }






                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent5_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }







                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }








                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }
                                            foundevent = "";
                                        }

                                    }
                                    #endregion
                                    break;
                                }
                                component = "";
                            }
                        }
                        #endregion
                    }





                    if (container6 != "")
                    {
                        SqlCommand Cmdcontainers = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'" + container6 + "' ,'','' ,'','','' )", aConnection);
                        Cmdcontainers.ExecuteNonQuery();


                        //SqlCommand getcontainern = new SqlCommand("select * from table_ViewContainers where intId = '" + (i + 1) + "'", aConnection);

                        //DataTable dtcontainersn = new DataTable();
                        //using (SqlDataAdapter a = new SqlDataAdapter(getcontainern))
                        //{
                        //    a.Fill(dtcontainersn);
                        //}


                        //if (dtcontainersn != null && dtcontainersn.Rows.Count > 0)
                        //{
                        //    ncontainer1 = dtcontainersn.Rows[0]["strViewContainer1_1"].ToString();
                        //    ncontainer2 = dtcontainersn.Rows[0]["strViewContainer2_1"].ToString();
                        //    ncontainer4 = dtcontainersn.Rows[0]["strViewContainer4_1"].ToString();
                        //    ncontainer3 = dtcontainersn.Rows[0]["strViewContainer3_1"].ToString();

                        //    ncontainer5 = dtcontainersn.Rows[0]["strViewContainer55_1"].ToString();
                        //    ncontainer6 = dtcontainersn.Rows[0]["strViewContainer6_1"].ToString();

                        //    if (ncontainer1 != "")
                        //    {
                        //        continue;
                        //    }
                        //    else if (ncontainer2 != "")
                        //    {
                        //        continue;
                        //    }
                        //    else if (ncontainer4 != "")
                        //    {
                        //        continue;
                        //    }
                        //    else if (ncontainer3 != "")
                        //    {
                        //        continue;
                        //    }
                        //    else if (ncontainer5 != "")
                        //    {
                        //        continue;
                        //    }
                        //    else if (ncontainer6 != "")
                        //    {
                        //        continue;
                        //    }

                        //}



                        #region component

                        for (int componentloop = i; componentloop <= dtcontainerscount.Rows.Count; componentloop++)
                        {
                            SqlCommand getcomponent = new SqlCommand("select * from table_ViewComponent where intId = '" + componentloop + "'", aConnection);

                            DataTable dtcomponent = new DataTable();
                            using (SqlDataAdapter a = new SqlDataAdapter(getcomponent))
                            {
                                a.Fill(dtcomponent);
                            }
                            if (dtcomponent != null && dtcomponent.Rows.Count > 0)
                            {
                                component = dtcomponent.Rows[0]["strViewComponent1_1"].ToString();
                                if (component != "")
                                {
                                    SqlCommand Cmdcomponent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'" + component + "','' ,'','','' )", aConnection);
                                    Cmdcomponent.ExecuteNonQuery();

                                    #region events
                                    for (int eventloop = i; eventloop <= dtcontainerscount.Rows.Count; eventloop++)
                                    {

                                        SqlCommand getevent = new SqlCommand("select * from table_Events where intId = '" + eventloop + "'", aConnection);

                                        DataTable dtevent = new DataTable();
                                        using (SqlDataAdapter a = new SqlDataAdapter(getevent))
                                        {
                                            a.Fill(dtevent);
                                        }


                                        if (dtevent != null && dtevent.Rows.Count > 0)
                                        {
                                            foundevent = dtevent.Rows[0]["strEvent1_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation1"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }










                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent2_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation2"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent3_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation3"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent4_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation4"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }






                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent5_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }







                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }








                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }
                                            foundevent = "";
                                        }

                                    }
                                    #endregion


                                    break;
                                }


                                component = "";
                                component = dtcomponent.Rows[0]["strViewComponent2_1"].ToString();
                                if (component != "")
                                {
                                    SqlCommand Cmdcomponent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'" + component + "','' ,'','','' )", aConnection);
                                    Cmdcomponent.ExecuteNonQuery();

                                    #region events
                                    for (int eventloop = i; eventloop <= dtcontainerscount.Rows.Count; eventloop++)
                                    {

                                        SqlCommand getevent = new SqlCommand("select * from table_Events where intId = '" + eventloop + "'", aConnection);

                                        DataTable dtevent = new DataTable();
                                        using (SqlDataAdapter a = new SqlDataAdapter(getevent))
                                        {
                                            a.Fill(dtevent);
                                        }


                                        if (dtevent != null && dtevent.Rows.Count > 0)
                                        {
                                            foundevent = dtevent.Rows[0]["strEvent1_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation1"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }










                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent2_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation2"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent3_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation3"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent4_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation4"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }






                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent5_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }







                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }








                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }
                                            foundevent = "";
                                        }

                                    }
                                    #endregion
                                    break;
                                }

                                component = "";
                                component = dtcomponent.Rows[0]["strViewComponent3_1"].ToString();
                                if (component != "")
                                {
                                    SqlCommand Cmdcomponent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'" + component + "','' ,'','','' )", aConnection);
                                    Cmdcomponent.ExecuteNonQuery();

                                    #region events
                                    for (int eventloop = i; eventloop <= dtcontainerscount.Rows.Count; eventloop++)
                                    {

                                        SqlCommand getevent = new SqlCommand("select * from table_Events where intId = '" + eventloop + "'", aConnection);

                                        DataTable dtevent = new DataTable();
                                        using (SqlDataAdapter a = new SqlDataAdapter(getevent))
                                        {
                                            a.Fill(dtevent);
                                        }


                                        if (dtevent != null && dtevent.Rows.Count > 0)
                                        {
                                            foundevent = dtevent.Rows[0]["strEvent1_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation1"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }










                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent2_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation2"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent3_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation3"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent4_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation4"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }






                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent5_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }







                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }








                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }
                                            foundevent = "";
                                        }

                                    }
                                    #endregion
                                    break;
                                }

                                component = "";


                                component = dtcomponent.Rows[0]["strViewComponent4_1"].ToString();
                                if (component != "")
                                {
                                    SqlCommand Cmdcomponent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'" + component + "','' ,'' ,'','')", aConnection);
                                    Cmdcomponent.ExecuteNonQuery();


                                    #region events
                                    for (int eventloop = i; eventloop <= dtcontainerscount.Rows.Count; eventloop++)
                                    {

                                        SqlCommand getevent = new SqlCommand("select * from table_Events where intId = '" + eventloop + "'", aConnection);

                                        DataTable dtevent = new DataTable();
                                        using (SqlDataAdapter a = new SqlDataAdapter(getevent))
                                        {
                                            a.Fill(dtevent);
                                        }


                                        if (dtevent != null && dtevent.Rows.Count > 0)
                                        {
                                            foundevent = dtevent.Rows[0]["strEvent1_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation1"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }










                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent2_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation2"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent3_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation3"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent4_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation4"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }






                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent5_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }







                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }








                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }
                                            foundevent = "";
                                        }

                                    }
                                    #endregion
                                    break;
                                }


                                component = "";
                                component = dtcomponent.Rows[0]["strViewComponent5_1"].ToString();
                                if (component != "")
                                {
                                    SqlCommand Cmdcomponent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'" + component + "','' ,'' ,'','')", aConnection);
                                    Cmdcomponent.ExecuteNonQuery();


                                    #region events
                                    for (int eventloop = i; eventloop <= dtcontainerscount.Rows.Count; eventloop++)
                                    {

                                        SqlCommand getevent = new SqlCommand("select * from table_Events where intId = '" + eventloop + "'", aConnection);

                                        DataTable dtevent = new DataTable();
                                        using (SqlDataAdapter a = new SqlDataAdapter(getevent))
                                        {
                                            a.Fill(dtevent);
                                        }


                                        if (dtevent != null && dtevent.Rows.Count > 0)
                                        {
                                            foundevent = dtevent.Rows[0]["strEvent1_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation1"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }










                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent2_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation2"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent3_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation3"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent4_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation4"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }






                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent5_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }







                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }








                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }
                                            foundevent = "";
                                        }

                                    }
                                    #endregion
                                    break;
                                }


                                component = "";
                                component = dtcomponent.Rows[0]["strViewComponent6_1"].ToString();
                                if (component != "")
                                {
                                    SqlCommand Cmdcomponent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'" + component + "','' ,'','' ,'')", aConnection);
                                    Cmdcomponent.ExecuteNonQuery();


                                    #region events
                                    for (int eventloop = i; eventloop <= dtcontainerscount.Rows.Count; eventloop++)
                                    {

                                        SqlCommand getevent = new SqlCommand("select * from table_Events where intId = '" + eventloop + "'", aConnection);

                                        DataTable dtevent = new DataTable();
                                        using (SqlDataAdapter a = new SqlDataAdapter(getevent))
                                        {
                                            a.Fill(dtevent);
                                        }


                                        if (dtevent != null && dtevent.Rows.Count > 0)
                                        {
                                            foundevent = dtevent.Rows[0]["strEvent1_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation1"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }










                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent2_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation2"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent3_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation3"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }









                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent4_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation4"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }






                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent5_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }







                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();


                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }








                                            foundevent = "";
                                            foundevent = dtevent.Rows[0]["strEvent6_1"].ToString();
                                            if (foundevent != "")
                                            {
                                                SqlCommand Cmdevent = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','" + foundevent + "' ,'','','" + dtevent.Rows[0]["navigation5"].ToString() + "' )", aConnection);
                                                Cmdevent.ExecuteNonQuery();

                                                SqlCommand getAction = new SqlCommand("select * from table_Actions where intId = '" + eventloop + "'", aConnection);

                                                DataTable dtAction = new DataTable();
                                                using (SqlDataAdapter a = new SqlDataAdapter(getAction))
                                                {
                                                    a.Fill(dtAction);
                                                }

                                                if (dtAction != null && dtAction.Rows.Count > 0)
                                                {
                                                    foundaction = dtAction.Rows[0]["strAction1_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }

                                                    foundaction = "";
                                                    foundaction = dtAction.Rows[0]["strAction2_1"].ToString();
                                                    if (foundaction != "")
                                                    {
                                                        SqlCommand Cmdaction = new SqlCommand("INSERT INTO table_Results (line,container,component,events,actions,parameters,navigation) Values ('" + i + "' ,'' ,'','' ,'" + foundaction + "','','' )", aConnection);
                                                        Cmdaction.ExecuteNonQuery();
                                                    }
                                                }
                                                break;
                                            }
                                            foundevent = "";
                                        }

                                    }
                                    #endregion
                                    break;
                                }
                                component = "";
                            }
                        }
                        #endregion
                    }
                }
            }



        }


        GridView1.DataBind();
        GridView1.Visible = true;


    }

    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {

        SqlConnection aConnection = new SqlConnection(getConnectionString());
        aConnection.Open();


        SqlCommand Cmd_for_result = new SqlCommand("select * from  table_Results", aConnection);
        Cmd_for_result.ExecuteNonQuery();
        DataTable dtforresult = new DataTable();
        using (SqlDataAdapter b = new SqlDataAdapter(Cmd_for_result))
        {
            b.Fill(dtforresult);
        }

        List<String> tableData = new List<string>();
        int count = 0;
        String newValue = null;
        if (dtforresult.Rows.Count > 0)
        {
            for (int j = 0; j <= dtforresult.Rows.Count; j++)
            {
                newValue = null;
                if (count < dtforresult.Rows.Count)
                {
                    newValue = dtforresult.Rows[count]["container"].ToString();

                    if (newValue != null)
                    {
                        count = count + 1;

                        if (count < dtforresult.Rows.Count)
                        {
                            if (dtforresult.Rows[count]["component"].ToString() != "")

                                newValue = newValue + "," + dtforresult.Rows[count]["component"].ToString();

                            if (newValue.Contains(","))
                            {
                                count = count + 1;

                                if (count < dtforresult.Rows.Count)
                                {
                                    if (dtforresult.Rows[count]["events"].ToString() != "")
                                    {
                                        newValue = newValue + "," + dtforresult.Rows[count]["events"].ToString();

                                        count = count + 1;

                                        if (count < dtforresult.Rows.Count)
                                        {
                                            if (dtforresult.Rows[count]["actions"].ToString() != "")
                                            {
                                                newValue = newValue + "," + dtforresult.Rows[count]["actions"].ToString();
                                                count = count + 1;
                                            }
                                        }

                                    }
                                }

                            }
                        }



                    }
                }
                else
                    break;
                //  else
                //     count = count + 1;

                tableData.Add(newValue);
                // count++;






            }
        }
        //Console.WriteLine(tableData[0]);
        {
            string path = @"d:\XMI.txt";
            File.WriteAllText(path, String.Empty);
            Random random = new Random();
            String id = null;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            if (!File.Exists(path))
            {

                id = new string(Enumerable.Repeat(chars, 20).Select(s => s[random.Next(s.Length)]).ToArray());
                string createText = "<?xml version=" + '"' + "1.0" + '"' + " encoding=" + '"' + "ASCII" + '"' + "?>" + Environment.NewLine;
                File.WriteAllText(path, createText);
            }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            id = new string(Enumerable.Repeat(chars, 20).Select(s => s[random.Next(s.Length)]).ToArray());
            string appendText = "<core:IFMLModel xmlns:xsi=" + '"' + "http://www.w3.org/2001/XMLSchema-instance" + '"' + " xmlns:core=" + '"' + "http://www.omg.org/spec/20130218/core" + '"' + " xmlns:ext=" + '"' + "http://www.omg.org/spec/20130218/ext" + '"' + " xmlns:uml=" + '"' + "http://www.eclipse.org/uml2/5.0.0/UML" + '"' + " id=" + '"' + "_" + id + '"' + ">" + Environment.NewLine;
            File.AppendAllText(path, appendText);

            id = new string(Enumerable.Repeat(chars, 20).Select(s => s[random.Next(s.Length)]).ToArray());
            appendText = "  <interactionFlowModel id=" + '"' + "_" + id + '"' + ">" + Environment.NewLine;
            File.AppendAllText(path, appendText);
            for (int c = 0; c < tableData.Count; c++)
            {

                id = new string(Enumerable.Repeat(chars, 20).Select(s => s[random.Next(s.Length)]).ToArray());
                string check = tableData[c].Split(',')[0];
                appendText = "    <interactionFlowModelElements xsi:type=" + '"' + "core:ViewContainer" + '"' + " id=" + '"' + "_" + id + '"' + " name=" + '"' + check + '"' + ">" + Environment.NewLine; ;
                File.AppendAllText(path, appendText);
                String type = null;
                if (tableData[c].Contains(","))
                {
                    if (tableData[c].Split(',')[1].Contains("list"))
                    {
                        type = "List";
                    }
                    else if (tableData[c].Split(',')[1].Contains("detail"))
                    {
                        type = "Detail";
                    }
                    else
                    {
                        type = "Form";

                    }

                    id = new string(Enumerable.Repeat(chars, 20).Select(s => s[random.Next(s.Length)]).ToArray());

                    string hello = TextBox2.Text.ToString();
                    string check2 = tableData[c].Split(',')[1].Replace(hello, "");
                    check2 = check2.Replace("Databinding", "");
                    check2 = check2.Replace("<", "");
                    check2 = check2.Replace(">", "");

                    appendText = "      <viewElements xsi:type=" + '"' + "ext:" + type + ' ' + "id=" + "_" + id + " name=" + '"' + check2 + ">" + Environment.NewLine; ;
                    File.AppendAllText(path, appendText);
                    if (tableData[c].Split(',').Count() > 2)
                    {
                        id = new string(Enumerable.Repeat(chars, 20).Select(s => s[random.Next(s.Length)]).ToArray());
                        appendText = "        <viewElementEvents id=" + '"' + id + '"' + " name=" + '"' + tableData[c].Split(',')[2] + '"' + ">" + Environment.NewLine; ;
                        File.AppendAllText(path, appendText);
                    }

                    appendText = "        </viewElementEvents>" + Environment.NewLine;
                    File.AppendAllText(path, appendText);

                    id = new string(Enumerable.Repeat(chars, 20).Select(s => s[random.Next(s.Length)]).ToArray());
                    if (tableData[c].Split(',')[1].Contains("<"))
                    {
                        appendText = "        <viewComponentParts xsi:type=" + '"' + "core:DataBinding" + '"' + " id=" + "_" + id + " name=" + '"' + tableData[c].Split(',')[1].Split('<')[1].Replace(">", "") + '"' + "/>" + Environment.NewLine;
                        File.AppendAllText(path, appendText);
                    }

                    appendText = "      </viewElements>" + Environment.NewLine;
                    File.AppendAllText(path, appendText);
                }

                appendText = "    </interactionFlowModelElements>" + Environment.NewLine;
                File.AppendAllText(path, appendText);


                if (tableData[c].Split(',').Count() > 3)
                {
                    id = new string(Enumerable.Repeat(chars, 20).Select(s => s[random.Next(s.Length)]).ToArray());
                    string check4 = tableData[c].Split(',')[3];
                    appendText = "    <interactionFlowModelElements xsi:type=" + '"' + "core:IFMLAction" + '"' + " id=" + '"' + "_" + id + '"' + " name=" + '"' + check4 + '"' + ">" + Environment.NewLine; ;
                    File.AppendAllText(path, appendText);

                    appendText = "    </interactionFlowModelElements>" + Environment.NewLine;
                    File.AppendAllText(path, appendText);
                }



            }

            appendText = "  </interactionFlowModel>" + Environment.NewLine;
            File.AppendAllText(path, appendText);
            id = new string(Enumerable.Repeat(chars, 20).Select(s => s[random.Next(s.Length)]).ToArray());
            appendText = "  <domainModel id=" + '"' + "_" + id + '"' + ">" + Environment.NewLine;
            File.AppendAllText(path, appendText);
            appendText = "    <domainElements xsi:type=" + '"' + "core:UMLDomainConcept" + '"' + " id=" + '"' + "_" + id + '"' + " name=" + '"' + TextBox2.Text + " dataBinding=" + '"' + "//@interactionFlowModel/@interactionFlowModelElements.4/@viewElements.0/@viewComponentParts.0" + '"' + ">" + Environment.NewLine;
            File.AppendAllText(path, appendText);
            appendText = "      <classifier xsi:type=" + '"' + "uml:Class" + '"' + " href=" + '"' + "../../" + TextBox2.Text + "/model.uml#_4m7qoN9aEeeJu-IOo6oh1Q" + '"' + "/>" + Environment.NewLine; ;
            File.AppendAllText(path, appendText);
            appendText = "    </domainElements>" + Environment.NewLine;
            File.AppendAllText(path, appendText);
            appendText = "  </domainModel>" + Environment.NewLine;
            File.AppendAllText(path, appendText);
            appendText = "</core:IFMLModel>" + Environment.NewLine;
            File.AppendAllText(path, appendText);
        }
        string myfile = System.IO.File.ReadAllText(@"d:\XMI.txt");
        myfile = myfile.ToString();

        TextBox3.Text = myfile;
        Server.HtmlEncode(TextBox3.Text);
        TextBox3.Visible = true;
}

    

    protected void Button3_Click(object sender, EventArgs e)
    {
        TextBox3.Text = string.Empty; 
        TextBox3.Visible = false;

        SqlConnection aConnection = new SqlConnection(getConnectionString());
        aConnection.Open();

        
        string path2 = @"d:\domain model\XMI.txt";
        File.WriteAllText(path2, String.Empty);
        Random random = new Random();
        String id = null;
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        if (!File.Exists(path2))
        {

            id = new string(Enumerable.Repeat(chars, 20).Select(s => s[random.Next(s.Length)]).ToArray());
            string createText = "<?xml version=" + '"' + "1.0" + '"' + " encoding=" + '"' + "UTF-8" + '"' + "?>" + Environment.NewLine;
            File.WriteAllText(path2, createText);
        }


        string appendText = "<uml:Model xmi:version=" + '"' + "20131001" + '"' + " xmlns:xmi=" + '"' + "http://www.omg.org/spec/XMI/20131001" + '"' + " xmlns:uml=" + '"' + "http://www.eclipse.org/uml2/5.0.0/UML" + '"' + " xmi:id" + '"' + "_" + id + '"' + "http://www.eclipse.org/uml2/5.0.0/UML" + '"' + " name=" + '"' + "model" + '"' + ">" + Environment.NewLine;
        File.AppendAllText(path2, appendText);
        string appendText2 = "  <packagedElement xmi:type=" + '"' + "uml:Class" + '"' + " xmi:id=" + '"' + "_" + id + '"' + " name=" + '"' + TextBox2.Text + '"' + "/>" + Environment.NewLine;
        File.AppendAllText(path2, appendText2);
        string appendText3 = "</uml:Model>" + Environment.NewLine;
        File.AppendAllText(path2, appendText3);
        {
            string umlfile = System.IO.File.ReadAllText(@"d:\domain model\XMI.txt");
            umlfile = umlfile.ToString();

            TextBox3.Text = umlfile;
            TextBox3.Visible = true;
            
        }
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void SqlDataSource2_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        SqlConnection aConnection = new SqlConnection(getConnectionString());
        aConnection.Open();
        

    }
    protected void SqlDataSource2_Selecting1(object sender, SqlDataSourceSelectingEventArgs e)
    {
            }
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        SqlConnection aConnection = new SqlConnection(getConnectionString());
        aConnection.Open();
        ListBox2.DataBind();
        ListBox2.Visible = true;


        
    }
    protected void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        SqlConnection aConnection = new SqlConnection(getConnectionString());
        aConnection.Open();
        ListBox3.DataBind();
        ListBox3.Visible = true;
        
    }
    protected void ListBox3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button4_Click1(object sender, EventArgs e)
    {
        SqlConnection aConnection = new SqlConnection(getConnectionString());
        aConnection.Open();
        ListBox1.DataBind();
        ListBox1.Visible = true;

        

    }
    protected void ListBox1_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        SqlConnection aConnection = new SqlConnection(getConnectionString());
        aConnection.Open();
        ListBox4.DataBind();
        ListBox4.Visible = true;

    }
}
   

    





    


    
    

  
        
    
    
    
