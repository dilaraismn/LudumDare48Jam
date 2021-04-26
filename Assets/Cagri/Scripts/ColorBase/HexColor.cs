namespace Cagri.Scripts.ColorBase
{
    public class HexColor : ColorObjectBase
    {
        public override void Active()
        {
            base.Active();
            gameObject.SetActive(true);
        }

        public override void DeActive()
        {
            base.DeActive();
            gameObject.SetActive(false);
        }
    }
}
