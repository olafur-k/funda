const Home = (function () {
    'use strict';

    const agentListPath = "/Home/AgentList/";

    function _loadAgents() {
        _loadSingleAgentsList(false, "#js-agent-list");
        _loadSingleAgentsList(true, "#js-agent-garden-list");
    }

    function _loadSingleAgentsList(withGarden, containerSelector) {
        $.get(agentListPath, { withGarden: withGarden })
            .done((data) => {
                $(containerSelector).html(data);
            })
            .fail((err) => {
                console.log(err);
                $(containerSelector).html(err.status + " " + err.statusText);
            })
    }

    return {
        init: () => {
            $(document).ready(() => {
                if ($("#js-home").length) {
                    _loadAgents();
                }
            });
        },
    };
})();

Home.init();
