namespace Website.Metadata.Api;

using System.Collections.Generic;

using Website.Metadata.Model;

public interface PageMetadataRepository
{
    PageNavigation Nav();
    IEnumerable<PageMetadataModel> All();
    PageMetadataModel Get(string route);
}
