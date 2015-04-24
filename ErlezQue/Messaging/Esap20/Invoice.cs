using ErlezQue.Domain;
using ErlezQue.Messaging.GrossController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErlezQue.Messaging.Esap20
{
    /// <summary>
    /// Tar hand om logiken kring att spara en INVOIC
    /// </summary>
    public class Invoice
    {
        private int postId;
        private long lineId;
        private int _elementCount;
        //Head 1..1
        private Head _head;
        //HeadRef 0..*
        private IEnumerable<HeadRef> _headRefs;
        //Company 2..*
        private IEnumerable<Company> _companies;
        //Bet 1..1
        private Bet _bet;
        //Tdt 0..*
        private IEnumerable<Tdt> _tdts;
        //Tod 0..*
        private IEnumerable<Tod> _tods;
        //Alc 0..*
        private IEnumerable<Alc> _alcs;
        //Line 1..*
        private IEnumerable<Line> _lines;
        //LineRef 0..*
        private IEnumerable<LineRef> _lineRefs;
        //LinePri 1..*
        private IEnumerable<LinePri> _linePris;
        //LineTax 1..*
        private IEnumerable<LineTax> _lineTaxes;
        //LineAlc 0..*
        private IEnumerable<LineAlc> _lineAlcs;
        //Sum 1..1
        private Sum _sum;
        //SumTax 1..*
        private IEnumerable<SumTax> _sumTaxes;    

        /// <summary>
        /// Spara ett EDI meddelande
        /// </summary>
        public Invoice(Head head, 
            IEnumerable<HeadRef> headRefs, 
            IEnumerable<Company> companies, 
            Bet bet, 
            IEnumerable<Tdt> tdts, 
            IEnumerable<Tod> tods, 
            IEnumerable<Alc> alcs, 
            IEnumerable<Line> lines, 
            IEnumerable<LineRef> lineRefs, 
            IEnumerable<LinePri> linePris, 
            IEnumerable<LineTax> lineTaxes, 
            IEnumerable<LineAlc> lineAlcs, 
            Sum sum, 
            IEnumerable<SumTax> sumTaxes)
        {
            _elementCount = 0;
            _head = head;
            _headRefs = headRefs;
            _companies = companies;
            _bet = bet;
            _tdts = tdts;
            _tods = tods;
            _alcs = alcs;
            _lines = lines;
            _lineRefs = lineRefs;
            _linePris = linePris;
            _lineTaxes = lineTaxes;
            _lineAlcs = lineAlcs;
            _sum = sum;
            _sumTaxes = sumTaxes;
        }

        public int Save(bool saveData) 
        {
            // Validering
            if (_head.InvoiceType == "381")
            {
                if (string.IsNullOrEmpty(_head.CreditReason))
                    throw new Exception("Fel (T0061): " + this.GetType());
            }

            //Insert
            try
            {
                var gross = new GrossHead();
                postId = gross.Insert(saveData, _head);
                _elementCount++;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // ev tillfällig null test pga utveckling
            if (_headRefs != null)
            {
                int countTdt = 1;
                foreach (var item in _headRefs)
                {
                    item.PostId = postId;
                    item.HeadRefCount = countTdt++;
                    try
                    {
                        var gross = new GrossHeadRef();
                        gross.Insert(saveData, item);
                        _elementCount++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.InnerException);
                    }
                }
            }


            // ev tillfällig null test pga utveckling
            if (_companies != null)
            {
                int countCompany = 1;
                foreach (var item in _companies)
                {
                    item.PostId = postId;
                    item.CompanyCount = countCompany++;
                    try
                    {
                        var gross = new GrossCompany();
                        gross.Insert(saveData, item);
                        _elementCount++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.InnerException);
                    }
                }
            }

            // ev tillfällig null test pga utveckling
            if (_bet != null)
            {
                try
                {
                    _bet.PostId = postId;
                    var gross = new GrossBet();
                    gross.Insert(saveData, _bet);
                    _elementCount++;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            // ev tillfällig null test pga utveckling
            if (_tdts != null)
            {
                int countTdt = 1;
                foreach (var item in _tdts)
                {
                    item.PostId = postId;
                    item.TdtCount = countTdt++;
                    try
                    {
                        var gross = new GrossTdt();
                        gross.Insert(saveData, item);
                        _elementCount++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.InnerException);
                    }
                }
            }

            // ev tillfällig null test pga utveckling
            if (_tods != null)
            {
                int countTods = 1;
                foreach (var item in _tods)
                {
                    item.PostId = postId;
                    item.TodCount = countTods++;
                    try
                    {
                        var gross = new GrossTod();
                        gross.Insert(saveData, item);
                        _elementCount++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.InnerException);
                    }
                }
            }

            // ev tillfällig null test pga utveckling
            if (_alcs != null)
            {
                int countAlcs = 1;
                foreach (var item in _alcs)
                {
                    item.PostId = postId;
                    item.AlcCount = countAlcs++;
                    try
                    {
                        var gross = new GrossAlc();
                        gross.Insert(saveData, item);
                        _elementCount++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.InnerException);
                    }
                }
            }

            // ev tillfällig null test pga utveckling
            if (_lines != null)
            {
                int countLines = 1;
                foreach (var item in _lines)
                {
                    item.PostId = postId;
                    item.LineCount = countLines++;
                    try
                    {
                        var gross = new GrossLine();
                        lineId = gross.Insert(saveData, item);
                        _elementCount++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.InnerException);
                    }
                }
            }

            // ev tillfällig null test pga utveckling
            if (_lineRefs != null)
            {
                int countLineRefs = 1;
                foreach (var item in _lineRefs)
                {
                    item.LineId = lineId;
                    item.LineRefCount = countLineRefs++;
                    try
                    {
                        var gross = new GrossLineRef();
                        gross.Insert(saveData, item);
                        _elementCount++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.InnerException);
                    }
                }
            }

            // ev tillfällig null test pga utveckling
            if (_linePris != null)
            {
                int countLinePris = 1;
                foreach (var item in _linePris)
                {
                    item.LineId = lineId;
                    item.LinePriCount = countLinePris++;
                    try
                    {
                        var gross = new GrossLinePri();
                        gross.Insert(saveData, item);
                        _elementCount++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.InnerException);
                    }
                }
            }

            // ev tillfällig null test pga utveckling
            if (_lineTaxes != null)
            {
                int countLineTaxes = 1;
                foreach (var item in _lineTaxes)
                {
                    item.LineId = lineId;
                    item.LineTaxCount = countLineTaxes++;
                    try
                    {
                        var gross = new GrossLineTax();
                        gross.Insert(saveData, item);
                        _elementCount++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.InnerException);
                    }
                }
            }

            // ev tillfällig null test pga utveckling
            if (_lineAlcs != null)
            {
                int countLineAlcs = 1;
                foreach (var item in _lineAlcs)
                {
                    item.LineId = lineId;
                    item.LineAlcCount = countLineAlcs++;
                    try
                    {
                        var gross = new GrossLineAlc();
                        gross.Insert(saveData, item);
                        _elementCount++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.InnerException);
                    }
                }
            }

            // ev tillfällig null test pga utveckling
            if (_sum != null)
            {
                try
                {
                    _sum.PostId = postId;
                    var gross = new GrossSum();
                    gross.Insert(saveData, _sum);
                    _elementCount++;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            // ev tillfällig null test pga utveckling
            if (_sumTaxes != null)
            {
                int countSumTaxes = 1;
                foreach (var item in _sumTaxes)
                {
                    item.PostId = postId;
                    item.SumTaxCount = countSumTaxes++;
                    try
                    {
                        var gross = new GrossSumTax();
                        gross.Insert(saveData, item);
                        _elementCount++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.InnerException);
                    }
                }
            }

            return _elementCount;
        }
    }
}
