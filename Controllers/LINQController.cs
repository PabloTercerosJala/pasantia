public class LINQController
{
    private readonly LINQService linqService;

    public LINQController(LINQService linqService)
    {
        this.linqService = linqService;
    }

    public object Projections()
    {
        return linqService.Projections();
    }

    public object Filtering()
    {
        return linqService.Filtering();
    }

    public object Partitioning()
    {
        return linqService.Partitioning();
    }

    public object Ordering()
    {
        return linqService.Ordering();
    }

    public object Quantification()
    {
        return linqService.Quantification();
    }

    public object GetElement()
    {
        return linqService.GetElement();
    }

    public object Aggregation()
    {
        return linqService.Aggregation();
    }

    public object Grouping()
    {
        return linqService.Grouping();
    }

    public object Joining()
    {
        return linqService.Joining();
    }
}