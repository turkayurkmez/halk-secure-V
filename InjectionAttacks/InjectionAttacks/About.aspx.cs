﻿using InjectionAttacks;
using System;
using System.Web.UI;

public partial class About : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        XSRFHelper.Check(this, HiddenField1);
    }
}