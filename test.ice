

module Test
{
    interface RangerAccessResource
    {
    }

    class RangerAccessResourceImp implements RangerAccessResource
    {
        string ownerUser;
    }

    interface RangerAccessRequest
    {
        RangerAccessResource getResource();
    }
}