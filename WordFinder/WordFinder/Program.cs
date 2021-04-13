using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFinderChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The following is a 64x64 letter matrix, type in a word to try to find it.\n" +
                "You can enter multiple words by separating them witha comma, no space.\n" +
                "(Hint: try 'strawberry', 'Television', 'CHARACTERS')\n\n");

            var matrix = new List<string>
            {
                "TBMJepWeENbOcPEHfyZCZYQyqwkpKYgQIbZFXpfsLySGPxhBJnxsLvzTjRuLoAOG",
                "CeHcMMMtLrOpBNpoyOiuhLMqShfrmMINEJODcjgKbLdutnQyOKJoUOwLoNRgBYns",
                "HGlBTHtMQkSLSJRGDNMAJegjtWLwwkaFSQfkPeyrmFggZcsnceZzfXnbsYeWbMdD",
                "AxhebkGIBCtbTgwITpgEfpMDmoWWbUxUjFIyngbPcOonvFpvCWNikJLUUMGIFNVH",
                "RRjdvZTqPKtTLPsOamiyLRVPHCTcqLtQBbSoeMCfhiKVqYkuliuYogLshTCSXati",
                "AUomiiKWUcnleEYtzplWRUatPiJpaYhFsVeOstrawberryTUqUqBxJQLmEwGyCUh",
                "CpCglZstnuSSYzsNpkWdzizsSIrWAAoBfTUJArWsmgudYGoLTmZaLWlfHqDexBxg",
                "TUAmGmAixkDtSHThgmsueoybhSYxOehMaFDYnpaiOOzenHJtlMdpZTXYGSlTNKDM",
                "EnBoXJyyoDJEKWchiIWSguOLpcxxCfpiSGNSiZGViYQlbKJFsqYKhGhdVlzIHQdI",
                "RqjekHsoEngcBHxnSpwNbClzrNJNVmCPxJLfwVDVZPNXFvnIyGjYHpKTBaRhpaNF",
                "SjtZneGUxmalUdAeCPZtrTgqAtmQMOLrbDdnVMxvdHCdzkLRvqZjREiSyAKtToKY",
                "pcVtlZFkiGEZkMILDXVHUGYwHwEsCITXHHodihCIWsrsFOwNUvxxurkqLNbcwBks",
                "DTjTVwVWYNiTBlDvHJKyofOwszVVmvPffjYPCFSqyOTAQwjMbTZHztCLLFNrufmR",
                "qwTLcIHydfrRnfeZmkHrMOGVMIrlMViHsgAmhOXtjGcxpTrLTnUUvMDxcSnJLQyb",
                "stdBPMzcjZccuAlyoBCHMpcknmFWhnixHBzwujgkJmcChALurVJiiewgVooeDInV",
                "AQaHeVmaXXXimJxOIIhrxTpRqKhuDKLJHkmPnsIMTBOkPKlTAuygeaCTjpUymJOV",
                "zeTzaKiEraOnhPAUhJjkMbWhxfYTRgvzPpXgIHcrfebHppolEXPRNYDCTEATKOzS",
                "fBYTGhIuRnqRxQjiQJEKysCVGfuTiaZBfNlAvFkBVARmjTiebCODPXUHyWvMayDm",
                "GRzcsMiVxBmRkeFewKUbgPJivVCNTcfenXlpPNxJjrSIYpDofHTMaTcWbEahucyM",
                "lcpCcoljuxjCchQpWCCQixPlDvMtsMrCUyFAVRxfWFuIXavdOUHZqpEatgpvcyHU",
                "mIIOfPsaBheDtUNfUIzznxYtiaoqYNfQOPPbfFlMjrGDUMeSoQirHTjcyANfVvXe",
                "YspgKTYhGLABrkqgSjXIWCrMkaXKitpFsWzROtxhEbJaCuEmUKPmwiZOjaBJYECU",
                "ewKyNtpTRXozNmBtrsntfLXapTVfukGNRtwTcNmAcSqfxhmrlXBhLAirelQajCHF",
                "mpVBlPVMgJypJqMlGPXjXlblzMfslRRZkuzmxfscmIllOJZJEsCmzswJGrktJWFQ",
                "CLHnBnvAXriZkUaGDZrcYOqRcWYSSbkdoFeamDduDZPVVeGtYpNWhFlsdbzGJkRF",
                "sngzXiDCONHWjOpSZmkhySncwlTtNPmOhgniRNKTtmRGkbagrZjoBqDNCrHWFvrT",
                "FuHPZUiVZkyLxJPWQTFjqBTvEssBanyqqrWguMPJAzxxMGbuWbtOxVBXWEcOVCcO",
                "HOxvPkuqupWSpaMONDJWaywzCozXVkwbsfOokehFBGCLaYZhkfoYvPuHfRFctpXg",
                "LxTvbluQRZlclwJQNINapcQeQTugYLPSwAfyXbzGXIbsqLrFCFxCjFUaYMqtaeys",
                "CDuPoUjGrCVJAdnVAaOWRGMcBeiETzVXCAsowejZMFlkDNuUFlbMabSPtinOdQPm",
                "bXjGOTuCgtloXQIhobfnPCWVgwfwBXgtfMEEONoUGbQhtemFouOqnPhkiISTWBrr",
                "OxrBsTvqJaRSekIOtvgnJdEurHPFVFPtkexlMcBSCVsKECxeAONczQVCaLAcHSHY",
                "RPldQbrMfpAhlpRWoLngiGqoHDijSxNScPSmxPmZSeoDnUZyMVebidimvDZFRbCe",
                "HSPzMcsokPJhRgiwtWjtvbygFJfpFbDgHoBcXAwnxldZDTOJLkcOUocThDrySHGU",
                "MbdSitAktMCEclTJITkvBQYaOLdhunHCQdpeFuYHdbWtmXdjUOnZdLMvwVYKmZeR",
                "ndBBemVKaKOwCSxopaqMWOrylODcFeXZLsoNAdpcJMLQFixZHdJAQHpDwmbfYVko",
                "DuXBjwJPnagehwNtoXBwRGXgZzjVlnstgNonIzxHRVGKVOccWUlFjPzEvmgyLZLg",
                "mdmUSotkNezqaChqqcpOVtyrzpCvUBmCsPcFVrfPloodmQuDCfcSGiFCDLltHYOx",
                "bnITgZYBDxOTfjwuSGDaoGMJDJZKCMaKBdWnNmLBPWAJRskhEhMqRpsMHrdJCCtn",
                "PHZIKXzGWeLkjMtxrIpfRfQDrBCGbsbGcWkrFIukMLmHPNgQnNMqWtlWWjGzJthx",
                "NPMsjcrtNSwgrRoDfVxbvwAlmpYhDsdWGldFETqfXfpnhTOAtffNGoGdOrYSeTNG",
                "zUaohedgUvsBVYhVLtuUZPbgVWeupFVZjlVgzZAZefoUBtkaMAOPOLXdFKNODBXx",
                "SXSIZUsTMYjCwvgofneOLepszxclKQaXKMiAaLMXQdSQZaMgKJXxPTAVKLoKQEyo",
                "XkbCeDqRYxSJdWUFHSVjvdzFWubuvHuIUMZEnvUOQzmULYlWNGcbxyylpLKLKTUj",
                "KzhAwvFNqKGbTDgtxXXweyQcwDunbyyolVOReZkQVRQulNegXKhpDtiJBOYdKBdC",
                "hwLEpHlPALyeyzVOruTrIheSHtzgBEkhkSJzqKownxuugvQVPkEWJQwkbTTShNGz",
                "izCEIxcqIggmAiCQpVKnOLqRAAjJZetPcIHHiUAEOHWikSpiTprjYexTHgNCpYyT",
                "PuqnqrjCCIxtOJVIRBHsbWGsPLPmORmwjaWREyEukWWZbqplkCYxgpEFfdLQGiEd",
                "VAKHpvSTIQUVdMrjieMDPujfmQrGotBAsgriMkQaDiTsTGXxsWLPLvIWfnWbVqLG",
                "VtEdvAzYDpCfsGTNoLucqvxFvWzHmkTvRYipLQABOukyqFMJTQUTZHPOiZsXbIHm",
                "QjUVfdFRamcmDZYDiAsEOPCqMwMOepYMNatxeDxdXqnoTEXCWUtNYPBieHiYCzJQ",
                "UBJAioKEhFzdSBytnviDpVfzXKmaOFCpoMCMwTwugIdadkGBTaPMsXYjpHttJLBe",
                "PqCfHmCYjJHrUXdNgzHWoyHlMcpZqufFVyNpoIbSGjajwvExEIPZWrCDjAKapmHI",
                "jlsxfEdQykdHDetvwvjtlbdqwZaaOgpGQcMmscLQooNzkVnlTfGtHmOSBBfIaQVl",
                "EgjwhfLeTVJqnZFQcCmtTRQhpVbFLKyRcWlIYpHONQMNeGILNkclsdwxNbpRVfQi",
                "mcfuxBHSNANUfnBvheUJDCrKLPAHPfuhTfcVYQewHTIlSOytUtVFZPCzaIlhVRiz",
                "FOOQwOiMBmXwMvmiJnvismDSimmvZHhpyrWdLNEYfCSVcjURKfLwcQaOBVRuvJxC",
                "ZBXBXwvRKxnieAACIBgorOrdHgACZMPBVuqoYxSkjNhnRyGwTcjxFozjWcjpgVdn",
                "vYcSQWxNaMdtioxulGGZqJEcHgzlYdnYNelmucothSszFiTZFfRNLnRSWTLQdoHa",
                "NgwdAJlHfMNfKNOLQVKfpcQckZuDfjfQqkSxFRkycRAZbQTYOYMYjlxzNyfiCRSu",
                "ojaatggAJFhAvktfMfzyXoTmbTDvdznbOrUqrmyoAoFEQHpxsfbyhhffKLHgDJFZ",
                "bjUxUyozdJHyfNuTrxFaVnBFKMnoxqJspufPhLiltUJvdMHixjTvQkAscaCcviHX",
                "iPyFNQOAEpmlDpNgMyyxVokeUNxeCaZbwgcKlwXOvxdJrcPDlXrzMdJegFFbSTMH",
                "YjXpnuxjjEAClRHLYZMvohvkuCrlgnYlUgWQpLtbDgLASaAYnITjCHcBlnZwuzLi"
            };
            var wordFinder = new WordFinder(matrix);

            matrix.ForEach(x => Console.WriteLine(x));
            Console.WriteLine("\nEnter your words below:\n");

            while (true)
            {
                var words = Console.ReadLine().Split(',');
                if (words[0].ToLower() == "exit") break;

                var foundWords = wordFinder.Find(words);

                if (foundWords.Count() == 0)
                {
                    Console.WriteLine("\nNone of the words were found. Try again or type 'exit' to exit.");
                }
                else
                {
                    Console.WriteLine("\nThe following words were found, ordered by frequency:\n");
                    ((List<string>)foundWords).ForEach(x => Console.WriteLine("> " + x));
                }

                Console.WriteLine("\n\n");
            }
        }
    }
}
