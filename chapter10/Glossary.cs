using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;

public partial class Glossary : Form {
    //存储读取到的数据的哈希表
    //private Hashtable glossary = new Hashtable();
    private LineHash glossary = new LineHash(5);
    public Glossary()
    {
        InitializeComponent();
    }
    //处理文本内容, 将数据按照要求放入哈希表
    private void BuildGlossary(LineHash g)
    {
        StreamReader inFile;
        string line;
        string[] words;
        inFile = File.OpenText(@"Test.txt");
        //逗号分割每行文本
        char[] delimiter = new char[] { ',' };
        //只要文件流没有到末尾, 就一行行读取文本
        while (inFile.Peek() != -1) {
            line = inFile.ReadLine();
            words = line.Split(delimiter);
            //按照逗号分隔的两部分, 前面的作为关键字, 后面的作为值
            g.Add(words[0], words[1]);
        }
        inFile.Close();
    }
    //将哈希表中的关键字都显示在ListBox控件中
    private void DisplayWords(LineHash g)
    {
        Object[] words = new Object[100];
        g.Keys.CopyTo(words, 0);
        for (int i = 0; i <= words.GetUpperBound(0); i++)
            if (!(words[i] == null))
                lstWords.Items.Add((words[i].ToString()));
    }
    //点击ListBox中的条目时, 查询哈希表, 并将对应的释义显示在指定的文本框
    private void Glossary_Load(object sender, EventArgs e)
    {
        BuildGlossary(glossary);
        DisplayWords(glossary);
    }

    private void lstWords_SelectedIndexChanged(object sender, EventArgs e)
    {
        Object word;
        word = lstWords.SelectedItem;
        txtDefinition.Text = glossary[word].ToString();
    }
}