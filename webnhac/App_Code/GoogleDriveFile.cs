﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class GoogleDriveFile
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string OriginalFilename { get; set; }
    public string ThumbnailLink { get; set; }
    public string IconLink { get; set; }
    public string WebContentLink { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}