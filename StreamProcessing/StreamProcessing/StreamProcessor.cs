namespace StreamProcessing
{
    public enum State
    {
        NORMAAL,
        ONZIN,
        ESCAPE
    }
    public class StreamProcessor
    {
        private State _currentState = State.NORMAAL;
        private State _previousState;
        private int _score;
        private int _scoreOnzin;
        private int _onzinHelper;
        private int _scoreHelper;
        public void ProcessStream(StreamReader input, out int score, out int scoreOnzin)
        {
            _score = 0;
            _scoreOnzin = 0;
            _onzinHelper = 0;
            _scoreHelper = 0;
            while (!input.EndOfStream)
            {

                ProcessChar((char)input.Read());
            }
            scoreOnzin = _scoreOnzin;
            score = _score;
        }
        private void ProcessChar(char b)
        {
            if (_currentState == State.ESCAPE)
            {
                _currentState = _previousState;
            }
            else
            {
                _previousState = _currentState;
                if (_currentState == State.ONZIN && b != '>' && b != '!')
                {
                    _scoreOnzin++;
                }
                else
                {
                    switch (b)
                    {
                        case '{':
                            _scoreHelper++;
                            _currentState = State.NORMAAL;
                            break;
                        case '}':
                            _score += _scoreHelper;
                            _scoreHelper = _scoreHelper > 0 ? _scoreHelper = _scoreHelper - 1 : _scoreHelper = 0;
                            _currentState = State.NORMAAL;
                            break;
                        case '<':
                            if (_currentState == State.ONZIN)
                            {
                                _scoreOnzin++;
                            }
                            _onzinHelper++;
                            _currentState = State.ONZIN;
                            break;
                        case '>':
                            _onzinHelper = _onzinHelper > 0 ? _onzinHelper = _onzinHelper - 1 : _onzinHelper = 0;
                            _currentState = _onzinHelper == 0 ? State.NORMAAL : State.ONZIN;
                            break;
                        case '!':
                            _currentState = State.ESCAPE;
                            break;
                        default:
                            _currentState = State.NORMAAL;
                            break;
                    }
                }
            }
        }
    }
}