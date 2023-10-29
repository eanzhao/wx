using aspnetapp.Liuyao;

namespace aspnetapp.MessageHandlers;

public class LiuyaoTextMessageService
{
    public string Jiegua(string message)
    {
        try
        {
            var input = Convert(message);
            var gua = new GuaFactory().Create(input);

            if (!Enum.TryParse(input.用神, out 六亲 yong))
            {
                if (input.用神 == "世爻")
                {
                    yong = gua.六爻.Single(yao => yao.世爻).六亲[0];
                }
            }

            var score = gua.Score(yong);
            return score.ToString();
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    private GuaMessage Convert(string message)
    {
        var input = new GuaMessage();

        try
        {
            var pieces = message.Split(' ');

            foreach (var liushisigua in Enum.GetNames<六十四卦>())
            {
                if (!message.Contains(liushisigua))
                {
                    throw new Exception("没有给出正确的卦象");
                }

                foreach (var piece in pieces)
                {
                    if (piece.Contains(liushisigua))
                    {
                        input.卦名 = piece;
                    }
                }
            }

            foreach (var wushen in Enum.GetNames(typeof(六爻五神)))
            {
                foreach (var piece in pieces)
                {
                    if (piece == wushen)
                    {
                        input.用神 = wushen;
                    }
                }
            }

            if (message.Contains("世爻"))
            {
                input.用神 = "世爻";
            }

            if (string.IsNullOrEmpty(input.用神))
            {
                throw new Exception("没有指定用神");
            }

            foreach (var dizhi in Enum.GetNames<地支>())
            {
                foreach (var piece in pieces)
                {
                    if (piece == dizhi && piece.Length == 1)
                    {
                        input.月支 = piece;
                    }

                    if (piece.Contains(dizhi) && piece.Length == 2)
                    {
                        input.日干支 = piece;
                    }
                }
            }

            if (string.IsNullOrEmpty(input.月支) || string.IsNullOrEmpty(input.日干支))
            {
                throw new Exception("没有给摇卦时间");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception(e.Message);
        }

        return input;
    }
}